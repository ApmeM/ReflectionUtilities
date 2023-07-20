namespace ReflectionUtilities.Test.ExampleObjects
{
    using System.ComponentModel;

    [Custom]
    [Custom]
    [Custom]
    [Category]
    public class ExampleObject : IExampleInterface
    {
        public int Field1;

        [Custom]
        [Custom]
        public int Field2;

        public string Property1 { get; set; }

        int IExampleInterface.Property1 { get; set; }

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
        public void Test()
        {
        }

        [Custom]
        [Custom]
        public void Test(string value)
        {
            this.Property1 = value;
        }

        public void AnotherTest()
        {
        }

        public void AnotherTest(int value)
        {
        }
    }
}
