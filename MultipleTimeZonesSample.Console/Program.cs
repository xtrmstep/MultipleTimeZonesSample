using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleTimeZonesSample.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Issue_withDateTime_Running_inDst_SprintForward_UserInput.Run();
            //Issue_withDateTime_Running_inDst_SprintForward.Run();
            Dst_FallBack_withDateTime_UserInput.Run();
            //Issue_withDateTime_Running_inDst_FallBack.Run();
            System.Console.ReadKey();
            
        }
    }
}
