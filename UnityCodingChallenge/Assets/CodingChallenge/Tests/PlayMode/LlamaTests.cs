using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class LlamaTests
{

    [UnityTest]
    public IEnumerator Captured_llama_can_die()
    {
        //LogAssert.Expect(LogType.Error, "LLAMA: Wander Around component not found");
        Time.timeScale = 100f;
        GameObject obj = new GameObject();
        Llama llama = obj.AddComponent<Llama>();
        llama.Reborn();
        llama.GetCaptured(Vector3.zero);

        yield return new WaitForSeconds(Llama.HUNGRY_TIMER * (llama.MaxHealth + 2));

        Assert.IsTrue(llama.Health <= 0);
    }
}
