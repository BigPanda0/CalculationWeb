using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication_Aimagambetov.Models.ViewModels
{
    public class CalculationViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        /// <summary>
        /// Высота слоя H0, м
        /// </summary>
        public double H0 { get; set; } = 3;
        [Required]
        /// <summary>
        /// Начальная темпер    атура материала t', 0С
        /// </summary>
        public double t_nachMat { get; set; } = 600;
        [Required]
        /// <summary>
        /// Начальная температура газа T', 0С
        /// </summary>
        public double T_nachTemp { get; set; } = 0;
        [Required]
        /// <summary>
        /// Скорость газа на свободное сечение шахты Wг, м/с
        /// </summary>
        public double Wg { get; set; } = 0.78;
        [Required]
        /// <summary>
        /// Средняя теплоемкость газа Cг, кДж/(м3 • К)
        /// </summary>
        public double Cg { get; set; } = 1.31;
        [Required]
        /// <summary>
        /// Расход материалов,Gм кг/с
        /// </summary>
        public double Gm { get; set; } = 1.72;
        [Required]
        /// <summary>
        /// Теплоемкость материалов Cм, кДж/(кг • К)
        /// </summary>
        public double Cm { get; set; } = 1.49;
        [Required]
        /// <summary>
        /// Объемный коэффициент теплоотдачи aV, Вт/(м3 • К)
        /// </summary>
        public double aV { get; set; } = 2460;
        [Required]
        /// <summary>
        /// Диаметр аппарата D, м
        /// </summary>
        public double D { get; set; } = 2;
        [Required]
        /// <summary>
        /// Отношение теплоемкостей потоков m
        /// </summary>
        /// <returns></returns>
        public double m { get; set; }
        [Required]
        /// <summary>
        /// Полная относительная высота слоя Y0
        /// </summary>
        /// <returns></returns>
        public double Y0 { get; set; }

        //Для графика
        public List<double> ns { get; set; }
        public List<double> Ys { get; set; }
        public List<double> ExpYs { get; set; }
        public List<double> MexpYs { get; set; }

        public List<double> Vs { get; set; }

        public List<double> Os { get; set; }

        public List<double> tNachs { get; set; }

        public List<double> Ts { get; set; }

        public List<double> Raz { get; set; }

    }
}
