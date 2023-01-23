namespace MathLib
{
    public class Calculation
    {
        private double ho;
        /// <summary>
        /// Высота слоя H0, м
        /// </summary>
        public double H0
        {
            get { return ho; }
            set 
            {
                ns = new();

                for (double i = 0; i <= value; i += 0.5)
                {
                    ns.Add(i);
                }
                ho = value;
            }
        }
        /// <summary>
        /// Начальная температура материала t', 0С
        /// </summary>
        public double t_nachMat { get; set; }
        /// <summary>
        /// Начальная температура газа T', 0С
        /// </summary>
        public double T_nachTemp { get; set; }
        /// <summary>
        /// Скорость газа на свободное сечение шахты Wг, м/с
        /// </summary>
        public double Wg { get; set; }
        /// <summary>
        /// Средняя теплоемкость газа Cг, кДж/(м3 • К)
        /// </summary>
        public double Cg { get; set; }
        /// <summary>
        /// Расход материалов,Gм кг/с
        /// </summary>
        public double Gm { get; set; }
        /// <summary>
        /// Теплоемкость материалов Cм, кДж/(кг • К)
        /// </summary>
        public double Cm { get; set; }
        /// <summary>
        /// Объемный коэффициент теплоотдачи aV, Вт/(м3 • К)
        /// </summary>
        public double aV { get; set; }
        /// <summary>
        /// Диаметр аппарата D, м
        /// </summary>
        public double D { get; set; }
        /// <summary>
        /// Площадь поперечного сечения аппарата S, м2
        /// </summary>
        /// <returns></returns>
        private double S()
        {
            return Math.PI * Math.Pow(D, 2) / 4;
        }
        /// <summary>
        /// Расход газа V, м3/c
        /// </summary>
        /// <returns></returns>
        private double Vg()
        {
            return S() * Wg;
        }
        /// <summary>
        /// Отношение теплоемкостей потоков m
        /// </summary>
        /// <returns></returns>
        public double m()
        {
            return (Gm * Cm) / (Vg() * Cg);
        }
        /// <summary>
        /// Полная относительная высота слоя Y0
        /// </summary>
        /// <returns></returns>
        public double Y0()
        {
            return (aV * S() * H0) / (Wg * S() * Cg * 1000);
        }

        //Для графика

        public double GetExpY0()
        {
            return 1 - m() * Math.Exp((-(1 - m()) * Y0()) / m());
        }

        public List<double> ns;

        public List<double> GetYs()
        {
            

            var Ys = new List<double>();
            foreach (var y in ns)
            {
                Ys.Add((aV * y) / (Wg * Cg * 1000));
            }
            return Ys;
        }

        public List<double> GetExpYs()
        {
            var exps = new List<double>();
            foreach (var Y in GetYs())
            {
                exps.Add(1 - Math.Exp(((m() - 1) * Y) / m()));
            }
            return exps;
        }
        public List<double> GetMexpYs()
        {

            var mexps = new List<double>();
            foreach (var Y in GetYs())
            {
                mexps.Add(1 - m() * Math.Exp((m() - 1) * Y / m()));
            }
            return mexps;
        }

        public List<double> GetVs()
        {


            var Vs = new List<double>();
            foreach (var expY in GetExpYs())
            {
                Vs.Add(expY / GetExpY0());
            }
            return Vs;
        }

        public List<double> GetOs()
        {
            var Os = new List<double>();
            foreach (var mexpY in GetMexpYs())
            {
                Os.Add(mexpY / GetExpY0());
            }
            return Os;
        }

        public List<double> Getts()
        {
            var ts = new List<double>();
            foreach (var V in GetVs())
            {
                ts.Add(t_nachMat + (T_nachTemp - t_nachMat) * V);
            }
            return ts;
        }

        public List<double> GetTs()
        {
            var Ts = new List<double>();
            foreach (var O in GetOs())
            {
                Ts.Add(t_nachMat + (T_nachTemp - t_nachMat) * O);
            }
            return Ts;
        }

        public List<double> GetRaz()
        {
            var Razs = new List<double>();
            for (int i = 0; i < Getts().Count; i++)
            {
                Razs.Add(Math.Abs(Getts()[i] - GetTs()[i]));
            }
            return Razs;
        }
    }
}
