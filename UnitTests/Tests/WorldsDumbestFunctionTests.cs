namespace UnitTests.Tests
{
    public static class WorldsDumbestFunctionTests
    {
        //Naming convention ClassName_MethodName_ExpectedResult
        public static void WorldsDumbestFunction_ReturnsPikachuIfZero_ReturnsString()
        {
            try
            {
                //Arrange - Go get your variables, whatever you neeed, your classes, your methods
                int number = 0;
                WorldsDumbestFunction worldDumbest = new WorldsDumbestFunction();

                //Act - Execute this function
                string result = worldDumbest.ReturnsPikachuIfZero(number);

                //Assert - Whatever is returned, is it what you want?
                if (result == "PIKACHU!")
                {
                    Console.WriteLine("PASSED: WorldsDumbestFunction.ReturnsPikachuIfZero.ReturnsString");
                }
                else 
                {
                    Console.WriteLine("FAILED: WorldsDumbestFunction.ReturnsPikachuIfZero.ReturnsString");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
