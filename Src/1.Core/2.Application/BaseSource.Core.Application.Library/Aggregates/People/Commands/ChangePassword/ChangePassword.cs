using BaseSource.Core.Application.Library.BaseApplication.RequestResponse.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Core.Application.Library.Aggregates.People.Commands.ChangePassword;
public class ChangePassword : ICommand<int>
{
    public int Id { get; set; }
    public string Password { get; set; }
}
