﻿using CoreLayer.Results.Abstract;
using CoreLayer.Results.Concrete;
using DTOLayer.PriceDescriptionDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstrsact
{
    public interface IPriceDescriptionsService
    {
        IDataResult<List<PriceDescriptionDTOs>> TGetOrderWithPricingCategory();
        IDataResult<List<PriceDescriptionActiveDTOs>> TGetActiv();
        IDataResult<PriceDescriptionDTOs> TGetById(int id);
        IResult TAdd(PricingDescriptionCreateDTOs entity);
        IResult TUpdate(PriceDescriptionDTOs entity);
        IResult TDelete(PriceDescriptionDTOs entity);
        IResult THardDelete(PriceDescriptionDTOs entity);
        IDataResult<List<PriceDescriptionActiveDTOs>> TGetActivByPricingId(int pricingId);
    }
}
