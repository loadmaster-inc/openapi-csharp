using System;
using System.ComponentModel.DataAnnotations;

namespace LoadMaster.Share.Models
{
    public class PackingCargoDto
    {

        public PackingCargoDto()
        {
            Id = Guid.NewGuid();
            Name = Guid.NewGuid().ToString();
            TypeRef = Guid.Empty;


            Quantity = 1;
            Length = 1.0f;
            Width = 1.0f;
            Height = 1.0f;
            Weight = 1.0f;
            Shape = 0;
            BearingLevel = 10;
            BottomOnly = false;
            QuantityInSuite = 1;
            CaseType = 0;
            InnerNumber = 1;
            NetWeight = 1;
            Color = RandomColor.Instance.GetNewColor().ToArgb();

            //暂时这么处理，等前端处理好，修改回来默认 裸装。
            InterimCase = 0;

            PackConstrain_0 = new PackConstrainDto() { LocType = 0, Allow = true, Support = true, MaxLayer = 100, MaxNoSupportRatio = 0.33f };
            PackConstrain_1 = new PackConstrainDto() { LocType = 1, Allow = true, Support = true, MaxLayer = 100, MaxNoSupportRatio = 0.33f };
            PackConstrain_2 = new PackConstrainDto() { LocType = 2, Allow = true, Support = true, MaxLayer = 100, MaxNoSupportRatio = 0.33f };
            PackConstrain_3 = new PackConstrainDto() { LocType = 3, Allow = true, Support = true, MaxLayer = 100, MaxNoSupportRatio = 0.33f };
            PackConstrain_4 = new PackConstrainDto() { LocType = 4, Allow = true, Support = true, MaxLayer = 100, MaxNoSupportRatio = 0.33f };
            PackConstrain_5 = new PackConstrainDto() { LocType = 5, Allow = true, Support = true, MaxLayer = 100, MaxNoSupportRatio = 0.33f };
        }


        public Guid Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        /// 
        [Required(ErrorMessage = "Name is required!")]
        [StringLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// 备注信息
        /// </summary>
        [StringLength(512)]
        public string Description { get; set; }

        /// <summary>
        /// 待装载的数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 装载时空间先后顺序,数值大的先装。
        /// </summary>
        public int Sequence { get; set; }

        /// <summary>
        /// 货物的运费或包装成本,预设的属性，当前产品中没有使用。
        /// </summary>
        public float Cost { get; set; }

        /// <summary>
        /// 装载紧急程度
        /// 0：标识 必须装载的货物
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// 套装名称
        /// </summary>
        [StringLength(255)]
        public string SuiteName { get; set; }

        /// <summary>
        /// 套装数量
        /// </summary>
        [Range(1,int.MaxValue)]
        public int QuantityInSuite { get; set; }

        /// <summary>
        /// 群组名称
        /// </summary>
        [StringLength(255)]
        public string GroupName { get; set; }

        /// <summary>
        /// 中间包装使用方式
        /// 0： 直接装载
        /// 1：自由选择托盘/箱子装载
        /// 2：指定容器装载
        /// 3：指定单品SKU包装
        /// </summary>
        public int InterimCase { get; set; }

        /// <summary>
        /// 指定的包装名称
        /// </summary>
        [StringLength(255)]
        public string UpcaseName { get; set; }

        /// <summary>
        /// 指定中间容器的名称
        /// </summary>
        [StringLength(255)]
        public string PointedContainerName { get; set; }

        /// <summary>
        /// 在指定包装的情况下，尾数货物处理方式
        /// 0：直接装载
        /// 1：生成部分包装，不与别的货物混装
        /// 2：与别的尾数货物混装在托盘上
        /// </summary>
        public int RemainderDeal { get; set; }

        /// <summary>
        /// 货物形状
        /// 0：方体
        /// 1：圆柱
        /// </summary>
        public int Shape { get; set; }

        /// <summary>
        /// 长度
        /// </summary>
        /// 
        [Range(1e-6f, float.MaxValue)]
        public float Length { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        /// 
        [Range(1e-6f, float.MaxValue)]
        public float Width { get; set; }
        /// <summary>
        /// 高度
        /// </summary>
        /// 
        [Range(1e-6f, float.MaxValue)]
        public float Height { get; set; }
        /// <summary>
        /// 重量
        /// </summary>
        /// 
        [Range(1e-6f, float.MaxValue)]
        public float Weight { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public int Color { get; set; }

        //public string ColorHex { get; set; }
        /// <summary>
        /// 承重级别，标识货物的承重能力的大小，承重级别低的货物可以放置在承重级别高的货物上面，反之不可！
        /// </summary>
        public int BearingLevel { get; set; }
        /// <summary>
        /// 只能放置在底部，不能压在任何别的货物上面。
        /// </summary>
        public bool BottomOnly { get; set; }
        /// <summary>
        /// 堆栈编码，相同堆栈编码的货物在计算最大堆码层数时，一起计算层数
        /// </summary>
        public string StackCode { get; set; }
        /// <summary>
        /// 包装类型
        /// </summary>
        public int CaseType { get; set; }
        /// <summary>
        /// 小件数量
        /// </summary>
        public int InnerNumber { get; set; }
        /// <summary>
        /// 净重
        /// </summary>
        public float NetWeight { get; set; }
        /// <summary>
        /// 立放时的装载约束
        /// </summary>
        public PackConstrainDto PackConstrain_0 { get; set; }
        /// <summary>
        /// 立放，水平旋转时的装载约束
        /// </summary>
        public PackConstrainDto PackConstrain_1 { get; set; }
        /// <summary>
        /// 侧放时的摆放约束
        /// </summary>
        public PackConstrainDto PackConstrain_2 { get; set; }
        /// <summary>
        /// 侧放，水平旋转时的装载约束
        /// </summary>
        public PackConstrainDto PackConstrain_3 { get; set; }
        /// <summary>
        /// 躺放时的摆放约束
        /// </summary>
        public PackConstrainDto PackConstrain_4 { get; set; }
        /// <summary>
        /// 躺放，水平旋转时的装载约束
        /// </summary>
        public PackConstrainDto PackConstrain_5 { get; set; }

        public Guid TypeRef { get; set; }
    }
}