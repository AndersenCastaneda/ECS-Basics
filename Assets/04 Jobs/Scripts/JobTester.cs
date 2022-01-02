using UnityEngine;
using Unity.Collections;
using Unity.Jobs;

public class JobTester : MonoBehaviour
{
	private void Start()
	{
		JobWithoutDependencies();

		JobWithDependencies();
	}

	private void JobWithoutDependencies()
	{
		var nativeArray = new NativeArray<int>(1, Allocator.TempJob);

		// 1. Create and Initialize the Job
		var job = new Job
		{
			Number = 10,
			Result = nativeArray
		};

		// 2. Schedule the Job
		var jobHandle = job.Schedule();

		// 3. Wait the Job to be completed
		jobHandle.Complete();

		Debug.Log($"job.Number: {job.Number} / nativeArray[0]: {nativeArray[0]}");

		// 4. Dispose the memory allocated
		nativeArray.Dispose();
	}

	private void JobWithDependencies()
	{
		var nativeArray = new NativeArray<int>(1, Allocator.TempJob);

		// 1. Create and Initialize the Jobs
		var firstJob = new Job
		{
			Number = 10,
			Result = nativeArray
		};

		var secondJob = new Job
		{
			Number = 3,
			Result = nativeArray,
		};

		// 2. Schedule the Jobs
		var firstHandle = firstJob.Schedule();
		var secondHandle = secondJob.Schedule(firstHandle);

		// 3. Wait the Job to be completed only for the job that is not a dependency
		secondHandle.Complete();

		Debug.Log($"job.Number: {firstJob.Number} / nativeArray[0]: {nativeArray[0]}");

		// 4. Dispose the memory allocated
		nativeArray.Dispose();
	}
}