﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BeerOverflow.Models.Contracts
{
    public interface IReviewable
    {
        ICollection<Review> Reviews { get; }
    }
}
