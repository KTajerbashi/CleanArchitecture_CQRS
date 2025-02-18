﻿using BaseSource.Core.Application.Library.BaseApplication.RequestResponse.Commands;

namespace BaseSource.Core.Application.Library.Aggregates.People.Commands.CreatePerson;

public class CreatePerson : ICommand<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
