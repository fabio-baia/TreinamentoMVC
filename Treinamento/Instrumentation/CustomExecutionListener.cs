using System.Diagnostics;
using System.Web.Instrumentation;

namespace Treinamento.Instrumentation
{
    public class CustomExecutionListener : PageExecutionListener
    {
        private readonly Stopwatch watch = new Stopwatch();

        public override void BeginContext(PageExecutionContext context)
        {
            watch.Start();
        }

        public override void EndContext(PageExecutionContext context)
        {
            watch.Stop();
            var e = string.Format("{0}: {1}", context.VirtualPath, watch.Elapsed);
            Trace.WriteLine(e);
            watch.Reset();
        }
    }
}