using System.ComponentModel.DataAnnotations;


using System;

namespace LoadMaster.Share.Models
{
    //[AutoMap(typeof(PackedBlock))]

    /// <summary>
    /// 装卸块数据
    /// 同一种货物，相同摆放模式，以行列层的方式组成装卸块
    /// </summary>
    public class PackedBlockDto
    {
        public Guid Id { get; set; }
        /// <summary>
        /// 装载顺序号
        /// </summary>
        public int BlockNo { get; set; }
        /// <summary>
        /// 摆放方式
        /// </summary>
        public int LocType { get; set; }
        /// <summary>
        /// 宽度坐标
        /// </summary>
        public float XPos { get; set; }
        /// <summary>
        /// 高度坐标
        /// </summary>
        public float YPos { get; set; }
        /// <summary>
        /// 长度坐标
        /// </summary>
        public float ZPos { get; set; }
        /// <summary>
        /// 宽度方向列数
        /// </summary>
        public int XNum { get; set; }
        /// <summary>
        /// 高度方向层数
        /// </summary>
        public int YNum { get; set; }
        /// <summary>
        /// 长度方向行数
        /// </summary>
        public int ZNum { get; set; }
        /// <summary>
        /// 宽度方向摆放间隙
        /// </summary>
        public float XInterstice { get; set; }
        /// <summary>
        /// 长度方向摆放间隙
        /// </summary>
        public float ZInterstice { get; set; }
        /// <summary>
        /// 高度方向摆放间隙
        /// </summary>
        public float YInterstice { get; set; }
        /// <summary>
        /// 装载货物的ID
        /// </summary>
        public Guid PackingGoodsID { get; set; }
        /// <summary>
        /// 托盘类型货物，内部装载的索引
        /// </summary>
        public Guid NestPackedUnitRef { get; set; }
        /// <summary>
        /// 简单货物还是托盘货物
        /// </summary>
        public bool IsSimple { get; set; }

        /// <summary>
        /// 货物类型名称
        /// </summary>
        [StringLength(1024)]
        public string GName { get; set; }

        /// <summary>
        /// 货物的备注
        /// </summary>
        [StringLength(1024)]
        public string GDescription { get; set; }
        /// <summary>
        /// 货物形状
        /// </summary>
        public int GShape { get; set; }
        /// <summary>
        /// 货物的基础宽度
        /// </summary>
        public float UnitX { get; set; }
        /// <summary>
        /// 货物的基础高度
        /// </summary>
        public float UnitY { get; set; }
        /// <summary>
        /// 货物的基础长度
        /// </summary>
        public float UnitZ { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public int GColor { get; set; }
        /// <summary>
        /// 货物的单体重量
        /// </summary>
        public float UnitWeight { get; set; }

        
    }
}