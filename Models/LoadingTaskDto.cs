using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoadMaster.Share.Models
{
    public class LoadingTaskDto
    {
        public LoadingTaskDto()
        {
            Name = DateTime.Now.ToString();
            ShippingDate = DateTime.Now;

            PackingCargoes = new List<PackingCargoDto>();
            PackingContainers = new List<PackingContainerDto>();
            InterimContainers = new List<PackingContainerDto>();
            LoadingOptions = new LoadingOptionDto();
            InterimOptions = new LoadingOptionDto();
            InterimUnits = new List<PackedUnitDto>();
            PackedUnits = new List<PackedUnitDto>();
            CannotPackList = new List<Guid>();
        }

        /// <summary>
        /// 任务类型
        /// 0 ：自动选择容器装完所有货物 。
        /// 1 ： 整柜下单，计算一个容器能否装完所有货物。装不完货物剩余。
        /// 2 ： 单品装载，测试容器和货物的匹配度。
        /// 3 ： 两阶段装载，货物先放入托盘或者木箱，然后放入集装箱。
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 任务Id
        /// </summary>
        public long Id { get; set; }
       
        /// <summary>
        /// 任务名称
        /// </summary>
        /// 
        [Required()]
        public string Name { get; set; }

        /// <summary>
        /// 任务描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomName { get; set; }

        /// <summary>
        ///任务的备注信息
        /// </summary>
        public string Destination { get; set; }

       
        /// <summary>
        /// 是否手动编辑过
        /// </summary>
        public bool IsManualEditted { get; set; }

        /// <summary>
        /// 需要支付的点数
        /// </summary>
        public float AmountToPay { get; set; }

        /// <summary>
        /// 是否已经支付了
        /// </summary>
        public bool HasPaid { get; set; }

        /// <summary>
        /// 支付明细
        /// </summary>
        public string ChargeDetails { get; set; }

        /// <summary>
        /// 装载概况
        /// </summary>
        public string LoadingSummary { get; set; }


        /// <summary>
        /// 发货日期
        /// </summary>
        [Required]
        public DateTime ShippingDate { get; set; }






        public List<PackingCargoDto> PackingCargoes { get; set; }
        public List<PackingContainerDto> InterimContainers { get; set; }
        public List<PackingContainerDto> PackingContainers { get; set; }
        public LoadingOptionDto InterimOptions { get; set; }
        public LoadingOptionDto LoadingOptions { get; set; }
        public List<PackedUnitDto> InterimUnits { get; set; }
        public List<PackedUnitDto> PackedUnits { get; set; }
        public void Normalize()
        {
            
        }

        public List<Guid> CannotPackList { get; set; }
    }
}