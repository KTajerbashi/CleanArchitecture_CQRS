using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureCQRS.Application.Library.Catalogs.Commands.Deleted;

public class DeleteCatalogItemCommand : INotification
{
    public DeleteCatalogItemCommand(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; private set; }
}
