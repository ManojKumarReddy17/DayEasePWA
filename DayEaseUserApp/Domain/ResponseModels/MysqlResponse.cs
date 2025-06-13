using Domain.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.ResponseModels
{
public class MysqlResponse<T>
    {
        
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
            public int Success { get; set; }
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public string? Message { get; set; }
            public T? Result { get; set; }
            public List<StateModel> Data { get; internal set; }
        }
    }
