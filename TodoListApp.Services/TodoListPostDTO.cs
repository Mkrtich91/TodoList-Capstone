using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListApp.Services;
public class TodoListPostDTO
{
    public int Idd { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsShared { get; set; }
}
