
namespace SharpLabs
{
    class Worker
    {
        private int age;
        private string name;
        private int experience;

        public Worker(int age = 0, string name = "", int experience = 0)
        {
            this.age = age;
            this.name = name;
            this.experience = experience;
        }

        public int getAge()
        {
            return age;
        }

        public string getName()
        {
            return name;
        }

        public int getExp()
        {
            return experience;
        }

        public void setAge(int age)
        {
            if(0 <= age && age <= 100)
            {
                this.age = age;
            }
            else
            {
                Console.WriteLine("Invalid age!");
            }
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setExp(int exp)
        {
            if(exp >= 0)
            {
                this.experience = exp;
            }
            else
            {
                Console.WriteLine("Invalid experience!");
            }
        }
    }
}
