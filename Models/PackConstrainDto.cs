using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadMaster.Share.Models
{
    /// <summary>
    /// 正常状态下，方体货物可以有六种不同的摆放方式。每一种摆放方式对应各自的装载约束。
    /// </summary>
    public class PackConstrainDto
    {
        /// <summary>
        /// 摆放类型
        /// 0： 立放
        /// 1：立放，水平旋转
        /// 2：侧放
        /// 3：侧放，水平旋转
        /// 4：躺放
        /// 5：躺放，水平旋转
        /// </summary>
        /// 
        [Range(0, 5)]
        public int LocType { get; set; }
        /// <summary>
        /// 是否允许这种摆放方式
        /// </summary>
        public bool Allow { get; set; }
        /// <summary>
        /// 可否支撑别的货物
        /// </summary>
        public bool Support { get; set; }
        /// <summary>
        /// 最大堆码层数
        /// </summary>
        [Range(1,int.MaxValue)]
        public int MaxLayer { get; set; }
        /// <summary>
        /// 最大悬空比率
        /// </summary>
        [Range(0.0, 1)]
        public float MaxNoSupportRatio { get; set; }
    }
}
