using Unity.Collections;
using Unity.Jobs;

public struct Job : IJob
{
	public int Number;
	public NativeArray<int> Result;

	public void Execute()
	{
		Result[0] = Number;
	}
}
