﻿namespace TrendWay.Discount.Dtos
{
    public class GetByIdDiscountCouponDto
    {
        public int CouponID { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
