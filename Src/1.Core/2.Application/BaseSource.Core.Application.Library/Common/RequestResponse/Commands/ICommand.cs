using MediatR;

namespace BaseSource.Core.Application.Library.Common.RequestResponse.Commands;

/// <summary>
/// جهت علامت گذاری کلاسی که پارامتر‌های ورودی درستور را دارد از این اینترفیس استفاده می‌شود
/// تمامی مدل های که برای کاماند نوشته میشود باید ازین ارث بری کنند
/// </summary>
public interface ICommand : IRequest
{
}

/// <summary>
/// جهت علامت گذاری کلاسی که پارامتر‌های ورودی درستور را دارد از این اینترفیس استفاده می‌شود
/// اگر به ازای دستور ارسال شده مقدار خروجی باید بازگشت داده شود از این اینترفیس استفاده می‌شود
/// </summary>
/// <typeparam name="TData">نوع داده‌ای که در ازای دستور باید بازگشت داده شود</typeparam>
public interface ICommand<TData> : IRequest<CommandResult<TData>>
{
}
