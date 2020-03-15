using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LoadMaster.Share.Models
{
    //[AutoMap(typeof(PackedUnit))]
    /// <summary>
    /// 装载结果数据
    /// </summary>
    public class PackedUnitDto
    {
        public PackedUnitDto()
        {
            PackedBlocks = new List<PackedBlockDto>();
            PackingContainerData = new PackingContainerDto();
        }

        public Guid Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        [StringLength(512)]
        public string Description { get; set; }
        /// <summary>
        /// 装载的阶段
        /// </summary>
        public int LoadStage { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public int SequenceNumber { get; set; }


        /// <summary>
        /// 所使用的容器数据
        /// </summary>   
        public PackingContainerDto PackingContainerData { get; set; }

        /// <summary>
        /// 装载块列表
        /// </summary>
        public virtual List<PackedBlockDto> PackedBlocks { get; set; }

        ///// <summary>
        ///// 货物统计，在两阶段装载中，这是最终的统计，中间生成的托盘被还原成最基础的货物。
        ///// </summary>
        //public List<GoodsStaticsDto> GoodsStaticsList { get; set; }
        ///// <summary>
        ///// 直接装载货物统计，在两阶段装载中，一个集装箱内可能有散货 和 散货打成的集结托盘，可以分别统计。
        ///// </summary>
        //public List<GoodsStaticsDto> DirectGoodsStaticsList { get; set; }

        
    }
}