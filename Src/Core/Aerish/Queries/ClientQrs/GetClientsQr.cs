using System;
using System.Collections.Generic;
using System.Text;

using Aerish.Domain.Models;

using TasqR;

namespace Aerish.Queries.ClientQrs
{
    public class GetClientsQr : ITasq<IEnumerable<ClientBO>>
    {
    }
}
