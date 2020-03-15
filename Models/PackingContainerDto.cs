using System;
using System.ComponentModel.DataAnnotations;

namespace LoadMaster.Share.Models
{

    //[AutoMap(typeof(PackingContainer))]
    /// <summary>
    /// 用于装载的容器数据
    /// </summary>
    public class PackingContainerDto
    {
        public PackingContainerDto()
        {
            Id = Guid.NewGuid();
            Name = Guid.NewGuid().ToString();
            Quantity = 100000;
            Weight = 1f;
            Maxload = 10000f;
        }


        public Guid Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [StringLength(255)]
        public string Name { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(512)]
        public string Description { get; set; }
        /// <summary>
        /// 容器的数量限制
        /// </summary>
        [Range(1,int.MaxValue)]
        public int Quantity { get; set; }
        /// <summary>
        /// 宽度方向保留尺寸
        /// </summary>
        public float XSave { get; set; }
        /// <summary>
        /// 高度方向保留尺寸
        /// </summary>
        public float YSave { get; set; }
        /// <summary>
        /// 长度方向保留尺寸
        /// </summary>
        public float ZSave { get; set; }
        /// <summary>
        /// 费用
        /// </summary>
        public float Cost { get; set; }
        /// <summary>
        /// 使用的装载阶段，单阶段装载时，默认为0，两阶段时，中间阶段为1.最终阶段为0
        /// </summary>
        public int LoadStage { get; set; }
        /// <summary>
        /// 容器类别： 0 纸箱，1 平托盘，2 箱式托盘或大箱子，3 集装箱，6 高低板车。
        /// </summary>
        public int Category { get; set; }
        /// <summary>
        /// 外径宽度
        /// </summary>
        public float OutX { get; set; }
        /// <summary>
        /// 外径高度
        /// </summary>
        public float OutY { get; set; }
        /// <summary>
        /// 外径长度
        /// </summary>
        public float OutZ { get; set; }
        /// <summary>
        /// 重量，容器的自重。
        /// </summary>
        public float Weight { get; set; }
        /// <summary>
        /// 最大载重量（不包括自重）
        /// </summary>
        [Range(1e-7f,double.MaxValue)]
        public float Maxload { get; set; }
        /// <summary>
        /// 内径宽度
        /// </summary>
        public float InnerX { get; set; }
        /// <summary>
        /// 内径高度
        /// </summary>
        public float InnerY { get; set; }
        /// <summary>
        /// 内径长度
        /// </summary>
        public float InnerZ { get; set; }
        /// <summary>
        /// 平托盘允许的最大长度方向出边
        /// </summary>
        public float ExtendSizeZ { get; set; }
        /// <summary>
        /// 平托盘允许的最大宽度方向出边
        /// </summary>
        public float ExtendSizeX { get; set; }
        /// <summary>
        /// 平托盘的最大摆放高度，包含托盘自身的高度
        /// </summary>
        public float MaxPackHeight { get; set; }
        /// <summary>
        /// 托盘的插齿方向
        /// </summary>
        public int ForkliftWays { get; set; }
        /// <summary>
        /// 集装箱角件宽度
        /// </summary>
        public float CornerX { get; set; }
        /// <summary>
        /// 集装箱角件高度
        /// </summary>
        public float CornerY { get; set; }
        /// <summary>
        /// 集装箱角件长度
        /// </summary>
        public float CornerZ { get; set; }
        /// <summary>
        /// 门宽
        /// </summary>
        public float DoorX { get; set; }
        /// <summary>
        /// 门高
        /// </summary>
        public float DoorY { get; set; }
        /// <summary>
        /// 高低板车前部平台的长度
        /// </summary>
        public float HathZ { get; set; }
        /// <summary>
        /// 高低板车的前部平台的高度
        /// </summary>
        public float HathY { get; set; }


        //数据库中不保存的
        //public string CateogoryName { get; set; }

        public void Normalize()
        {
            if (Category == 0 || Category == 2)
            {
                OutX = Math.Max(OutX, InnerX);
                OutY = Math.Max(OutY, InnerY);
                OutZ = Math.Max(OutZ, InnerZ);
            }
        }
    }
}