using lesson0.Validators;
using System;

namespace lesson0
{
    /// <summary>
    /// Person information
    /// </summary>
    class Person
    {
        public Person(
            int Height,
            int Weight,
            DateTime Birthday,
            string FirstName,
            string LastName)
        {
            if (IntValidator.Validate(Height))
                throw new ArgumentOutOfRangeException("Рост должен быть в диапазоне от 40 до 240 см");

            if (IntValidator.Validate(Weight))
                throw new ArgumentOutOfRangeException("Вес должен быть в диапазоне от 3 до 200 кг");

            if (StringValidator.Validate(FirstName))
                throw new ArgumentException("Имя должно содержать только буквы");

            if (StringValidator.Validate(LastName))
                throw new ArgumentException("Фамилия должна содержать только буквы");

            this.Height = Height;
            this.Weight = Weight;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.BirthDay = Birthday;
        }

        /// <summary>
        /// Height
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Weight
        /// </summary>
        public int Weight { get; private set; }

        /// <summary>
        /// FirstName
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// LastName
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// BirthDay
        /// </summary>
        public DateTime BirthDay { get; }

        /// <summary>
        /// FullName
        /// </summary>
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        /// <summary>
        /// Get an age
        /// </summary>
        public int Age
        {
            get
            {
                return (DateTime.Now - BirthDay).Days / 365;
            }
        }

        /// <summary>
        /// Change height
        /// </summary>
        public bool ChangeHeight(int height)
        {
            bool flag = IntValidator.Validate(height);
            if (flag)
                this.Height = height;
            return flag;
        }

        /// <summary>
        /// Change weight
        /// </summary>
        public bool ChangeWeight(int weight)
        {
            bool flag = IntValidator.Validate(weight);
            if (flag)
                this.Weight = weight;
            return flag;
        }

        /// <summary>
        /// Change firstname
        /// </summary>
        public bool ChangeFirstName(string firstName)
        {
            bool flag = StringValidator.Validate(firstName);
            if (flag)
                this.FirstName = firstName;
            return flag;
        }

        /// <summary>
        /// Change lastname
        /// </summary>
        public bool ChangeLasttName(string lastName)
        {
            bool flag = StringValidator.Validate(lastName);
            if (flag)
                this.FirstName = lastName;
            return flag;
        }

        /// <summary>
        /// Method ToString
        /// </summary>
        public override string ToString()
        {
            return $"Имя: {FullName}, Рост: {Height}, Вес: {Weight}, Возраст: {Age} лет";
        }
    }
}

