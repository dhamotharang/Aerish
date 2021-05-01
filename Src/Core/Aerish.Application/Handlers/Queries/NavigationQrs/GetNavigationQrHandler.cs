using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using Aerish.Domain.Models;
using Aerish.Queries.NavigationQrs;

using TasqR;

namespace Aerish.Application.Handlers.Queries.NavigationQrs
{
    public class GetNavigationQrHandler : TasqHandler<GetNavigationQr, NodeItemSetBO>
    {
        public override NodeItemSetBO Run(GetNavigationQr request)
        {
            NodeItemSetBO result = new NodeItemSetBO();

            List<NodeItemBO> nodeItems = new List<NodeItemBO>();

            nodeItems.Add(new NodeItemBO
            {
                Id = 1,
                Text = "Home",
                Icon = "home",
                Url = "/"
            });

            if (request.EmployeeID != null)
            {
                var employeeNode = new NodeItemBO
                {
                    Id = 10,
                    Text = "Employee",
                    Icon = "user",
                    Url = "Employee",
                    Children = new List<NodeItemBO>
                    {
                        new NodeItemBO
                        {
                            Id = 11,
                            Text = "Basic Pays",
                            Icon = "hyperlink-open",
                            Url = "Employee/BasicPays"
                        },
                        new NodeItemBO
                        {
                            Id = 12,
                            Text = "Earnings",
                            Icon = "hyperlink-open",
                            Url = "Employee/Earnings"
                        },
                        new NodeItemBO
                        {
                            Id = 13,
                            Text = "Deductions",
                            Icon = "hyperlink-open",
                            Url = "Employee/Deductions"
                        },
                        new NodeItemBO
                        {
                            Id = 40,
                            Text = "Payroll Runs",
                            Icon = "calculator",
                            Url = "Employee/PayrollRuns"
                        }
                    }
                };

                nodeItems.Add(employeeNode);
            }

            nodeItems.Add(new NodeItemBO
            {
                Id = 20,
                Text = "Parameters",
                Icon = "parameters",
                Children = new List<NodeItemBO>
                {
                    new NodeItemBO
                    {
                        Id = 90,
                        Text = "Payroll Schedule",
                        Icon = "hyperlink-open",
                        Url = "PayrollSchedule"
                    }
                }
            });

            nodeItems.Add(new NodeItemBO
            {
                Id = 50,
                Text = "Jobs",
                Icon = "parameter-date-time",
                Url = "Jobs"
            });

            nodeItems.Add(new NodeItemBO
            {
                Id = 60,
                Text = "Reports",
                Icon = "subreport",
                Url = "Reports"
            });

            string curUri = CleanCurrentUri(request.CurrentUri);

            markSelectedLoopBreaker = 0;
            var selected = TryMarkAsSelected(nodeItems, curUri);

            loopBreaker = 0;
            ExpandParents(nodeItems, selected);

            result.Nodes = nodeItems;
            result.SelectedNode = selected;

            return result;
        }

        int markSelectedLoopBreaker = 0;
        private NodeItemBO TryMarkAsSelected(IEnumerable<NodeItemBO> navigations, string currentUri)
        {
            NodeItemBO retVal = null;

            if (string.IsNullOrWhiteSpace(currentUri))
            {
                return null;
            }

            // TODO: change this 100 to how many nodes really in the collection including children
            if (markSelectedLoopBreaker == 100)
            {
                return null;
            }

            markSelectedLoopBreaker++;

            foreach (var item in navigations)
            {
                if (item.Url == currentUri)
                {
                    item.Selected = true;
                    retVal = item;
                }

                if (item.HasChild)
                {
                    retVal = retVal ?? TryMarkAsSelected(item.Children, currentUri);
                }
            }

            return retVal;
        }

        private NodeItemBO GetParent(IEnumerable<NodeItemBO> navigations, NodeItemBO item)
        {
            NodeItemBO parent = null;

            if (item == null)
            {
                return null;
            }

            foreach (var each in navigations)
            {
                if (each.HasChild)
                {
                    parent = parent ?? (each.Children.Any(a => a.Id == item.Id) ? each : GetParent(each.Children, item));
                }
            }

            return parent;
        }

        private string CleanCurrentUri(string currentUri)
        {
            string cleanUri = currentUri;

            if (!string.IsNullOrEmpty(currentUri))
            {
                if (Regex.IsMatch(currentUri, "^Employee/PayrollRuns/[a-zA-Z0-9\\-]+$"))
                {
                    cleanUri = "Employee/PayrollRuns";
                }
            }

            return cleanUri;
        }

        int loopBreaker = 0;
        private void ExpandParents(IEnumerable<NodeItemBO> navigations, NodeItemBO currentItem)
        {
            var parent = GetParent(navigations, currentItem);
            if (currentItem == null
                || parent == null
                || loopBreaker >= 100)
            {
                return;
            }

            loopBreaker++;

            parent.Expanded = true;

            ExpandParents(navigations, parent);
        }
    }
}