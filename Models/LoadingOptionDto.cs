using System;

namespace LoadMaster.Share.Models
{
    //[AutoMap(typeof(LoadingOption))]
    /// <summary>
    /// 优化装载时的业务规则
    /// </summary>
    public class LoadingOptionDto
    {
        public LoadingOptionDto()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        /// <summary>
        /// 使用规则的装载阶段
        /// 0 标识最终装载阶段
        /// 1 标识中间装载阶段
        /// </summary>
        /// 
        public int LoadStage { get; set; }

        /// <summary>
        /// 存在多种可用容器时的容器选择方式
        /// 0：依照输入的顺序依次装载
        /// 1：按照使用容器最少的原则选择容器装载完所有的货物
        /// 2：按照使用容器的总费用最少的原则来选择容器装载完所有的货物
        /// 3：简单的按照装载体积利用率最高来选择容器
        /// </summary>
        public int ContainerSelectMode { get; set; }

        /// <summary>
        /// 堆码方式
        /// 0：自由组合
        /// 1：相同制品相邻摆放
        /// 2：仅相同长宽的货物相关叠放
        /// </summary>
        public int PileMode { get; set; }

        /// <summary>
        /// 最大堆码层数计算方式
        /// 0：每一种货物单独计算最大堆码层数
        /// 1： 相同堆码层数的货物一起来计算最大堆码层数
        /// </summary>
        public int RestLayerMode { get; set; }

        /// <summary>
        /// 优先生成单品包装
        /// </summary>
        public bool PreferUnitLoad { get; set; }

        /// <summary>
        /// 判定满足单品包装条件：体积利用率
        /// </summary>
        public float MinVolRateForUnitLoad { get; set; }

        /// <summary>
        /// 宽度方向的摆放间隙
        /// </summary>
        public float XInterlace { get; set; }
        /// <summary>
        /// 长度方向的摆放间隙
        /// </summary>
        public float ZInterlace { get; set; }
        /// <summary>
        /// 高度方向的摆放间隙，似乎不应该存在，但是有的客户，货物会变形，通过设置高度方向摆放缝隙来应对。
        /// </summary>
        public float YInterlace { get; set; }
        /// <summary>
        /// 允许混合不同群组的货物在一个容器内
        /// </summary>
        public bool MixGroupsInContainer { get; set; }
        /// <summary>
        /// 允许把一个群组的货物分散到不同的容器
        /// </summary>
        public bool DivideAGroup { get; set; }
        /// <summary>
        /// 交叉深度，控制不同群组（这里的群组是个广泛的概念，相同的装载空间顺序可用视为一个群组；相同制品相邻摆放时，一种货物可用视为一个群组）的货物混合程度
        /// </summary>
        public float CombineDepth { get; set; }
        /// <summary>
        /// 体积利用不充分时，平铺处理
        /// </summary>
        public bool FloorLoading { get; set; }
        /// <summary>
        /// 限制装卸段长度
        /// </summary>
        public bool LimitSectionSize { get; set; }
        /// <summary>
        /// 最大装卸段长度
        /// </summary>
        public float MaxSectionSize { get; set; }

        /// <summary>
        /// 最小层覆盖率，用于托盘按层装载时，判定一个层数是否满足了要求，如果达到这个覆盖率，则可将其视为要给完整的层。
        /// </summary>
        public float MinLayerAreaRate { get; set; }
        /// <summary>
        /// 计算层覆盖率时，可用忽略的高度差
        /// </summary>
        public float MaxDiscrepancyCanIgnore { get; set; }
        /// <summary>
        /// 可用接受的最小托盘高度，防止生成大量的矮托盘
        /// </summary> 
        public float MinMixPalletHeight { get; set; }
        /// <summary>
        /// 是否允许托盘相互叠放
        /// </summary>
        public bool PalletPileEachOther { get; set; }
        /// <summary>
        /// 优先堆叠相同类型的托盘
        /// </summary>
        public bool PileSameTypePalletFirst { get; set; }
        /// <summary>
        /// 不同长宽的托盘相互叠放时，必须达到的底面重合率。
        /// </summary>
        public float MinOverlapRate { get; set; }
        /// <summary>
        /// 中间生成的混合托盘，默认的承重级别
        /// </summary>
        public int DefaultBearingLevelMixPallet { get; set; }
        /// <summary>
        /// 允许散货直接装载到集装箱
        /// </summary>
        public bool NakedGoodsIntoContainer { get; set; }
        /// <summary>
        /// 允许散货装载到托盘上面
        /// </summary>
        public bool NakedOnTheTopOfPallet { get; set; }

        /// <summary>
        /// 允许在托盘之间填塞散货
        /// </summary>
        public bool NakedBetweenPallets { get; set; }

        /// <summary>
        /// 指定中间容器的货物可否直接装入集装箱
        /// </summary>
        public bool AllowPointedContainerGoodsPackDirectly { get; set; }

        /// <summary>
        /// 可以生成中间包装的货物，可否直接装入到最终容器（集装箱）。
        /// </summary>
        public bool DivideUnitSKUToFill { get; set; }

        /// <summary>
        /// 实现阶梯摆放
        /// </summary>
        public bool LadderPackMode { get; set; }
        /// <summary>
        /// 阶梯长度
        /// </summary>
        public float LadderLength { get; set; }
        /// <summary>
        /// 阶梯高度
        /// </summary>
        public float LadderHeight { get; set; }

        /// <summary>
        /// 中间包装生成方式
        /// 0 代表生成预先指定高度的托盘
        /// 1 代表根据集装箱的高度，动态生成托盘来利用集装箱高度。
        /// </summary>
        public int InterimPackageGenerateMode { get; set; }

        /// <summary>
        /// 基础排序规则
        /// 0：最大维度排序
        /// 1：最大单体体积排序
        /// 2：容器适配率排序
        /// </summary>
        public int BaseRanking { get; set; }

        /// <summary>
        /// 块生成顺序
        /// 0 ；高度优先
        /// 1：宽度优先
        /// </summary>
        public int ModelGenerate { get; set; }

        public static LoadingOptionDto GetDefaultInterimOptions()
        {
            return new LoadingOptionDto
            {
                LoadStage = 1,
                ContainerSelectMode = 1,
                MaxDiscrepancyCanIgnore = 0.05f,
                MinMixPalletHeight = 0.2f,
                MinLayerAreaRate = 0.8f,
                DefaultBearingLevelMixPallet = 254,
                MixGroupsInContainer = true,
                DivideAGroup = true,
            };
        }

        public static LoadingOptionDto GetDefaultFinalOptions()
        {
            return new LoadingOptionDto
            {
                LoadStage = 0,
                ContainerSelectMode = 1,

                MinVolRateForUnitLoad = 0.85f,
                CombineDepth = 2,
                PalletPileEachOther = true,
                MinOverlapRate = 0.80f,
                NakedGoodsIntoContainer = true,
                NakedOnTheTopOfPallet = true,
                NakedBetweenPallets = true,
                MaxSectionSize = 2f,
                LadderHeight = 1f,
                LadderLength = 2f,

                MixGroupsInContainer = true,
                DivideAGroup = true,
            };
        }
    }
}