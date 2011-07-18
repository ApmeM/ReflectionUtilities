namespace ReflectionUtilites.Test
{
    using System.ComponentModel;

    [Custom]
    [Custom]
    [Custom]
    [Category]
    public class ExampleObject
    {
        public int Property1 { get; set; }

        [Custom]
        [Custom]
        [Custom]
        [Custom]
        public object Property2 { get; set; }

        [Description]
        [Category]
        public string Property3
        {
            set
            {
                this.Property2 = value;
            }
        }

        [Description]
        public ExampleObject Property4
        {
            get
            {
                return this;
            }
        }

        [Custom]
        public void TestMethod()
        {
        }

        [Custom]
        [Custom]
        public void TestMethod(int value)
        {
            this.Property1 = value;
        }

        public void AnotherTestMethod()
        {
        }
    }
}