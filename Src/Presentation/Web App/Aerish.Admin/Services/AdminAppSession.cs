using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Blazored.SessionStorage;
using Blazored.LocalStorage;

namespace Aerish.Admin.Shared
{
    public class AdminAppSession
    {
        bool useSessionStorage = false;

        private readonly ISessionStorageService p_SessionStorage;
        private readonly ILocalStorageService p_LocalStorage;

        public short ClientID { get; }


        public AdminAppSession
            (
                ISessionStorageService sessionStorage,
                ILocalStorageService localStorage,
                short clientID
            )
        {
            p_SessionStorage = sessionStorage;
            p_LocalStorage = localStorage;
            ClientID = clientID;
        }

        public async Task<int?> GetEmployeeID()
        {
            int? employeeSessionID = null;

            if (useSessionStorage)
            {
                if (await p_SessionStorage.ContainKeyAsync("EmployeeSessionID"))
                {
                    employeeSessionID = await p_SessionStorage.GetItemAsync<int?>("EmployeeSessionID");

                    if (employeeSessionID == 0)
                    {
                        employeeSessionID = null;
                    }
                }
            }
            else
            {
                if (await p_LocalStorage.ContainKeyAsync("EmployeeSessionID"))
                {
                    employeeSessionID = await p_LocalStorage.GetItemAsync<int?>("EmployeeSessionID");

                    if (employeeSessionID == 0)
                    {
                        employeeSessionID = null;
                    }
                }
            }

            if (employeeSessionID == null)
            {
                await LogoutEmployeeSession();
            }

            return employeeSessionID;
        }

        public async Task SetEmployeeSession(int employeeID)
        {
            if (useSessionStorage)
            {
                await p_SessionStorage.SetItemAsync("EmployeeSessionID", employeeID);
            }
            else
            {
                await p_LocalStorage.SetItemAsync("EmployeeSessionID", employeeID);
            }
        }

        public async Task LogoutEmployeeSession()
        {
            if (useSessionStorage)
            {
                await p_SessionStorage.RemoveItemAsync("EmployeeSessionID");
            }
            else
            {
                await p_LocalStorage.RemoveItemAsync("EmployeeSessionID");
            }
        }
    }
}