using System;
using System.Runtime.Serialization;
using Volo.Abp;

namespace Dignite.CarMarketplace.Dealers;

public class DealerAlreadyExistException : BusinessException
{
    public DealerAlreadyExistException(SerializationInfo serializationInfo, StreamingContext context)
        : base(serializationInfo, context)
    {
    }

    public DealerAlreadyExistException(Guid userId)
    {
        UserId = userId;

        Code = CarMarketplaceErrorCodes.Dealers.DealerAlreadyExist;

        WithData(nameof(UserId), UserId);
    }


    public virtual Guid UserId { get; }
}
