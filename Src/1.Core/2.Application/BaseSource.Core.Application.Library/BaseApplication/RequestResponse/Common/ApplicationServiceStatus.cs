﻿namespace BaseSource.Core.Application.Library.BaseApplication.RequestResponse.Common;
public enum ApplicationServiceStatus
{
    Ok = 1,
    NotFound = 2,
    ValidationError = 3,
    InvalidDomainState = 4,
    Exception = 5,
}

