using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestModels
{
    public class StateModel
    {
        public string StateId {  get; set; }
        public string StateName { get; set; }
        public bool IsDelete { get; set; }
    }
    public class StateResponse
    {
        public List<StateModel> Data { get; set; }
    }

}
