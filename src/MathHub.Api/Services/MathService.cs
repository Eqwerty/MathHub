namespace MathHub.Api.Services;

internal class MathService : IMathService
{
    public bool IsEven(int number)
    {
        while (number > 0)
        {
            number -= 2;
        }

        return number is 0;
    }
}
