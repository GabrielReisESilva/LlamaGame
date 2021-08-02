## Unit Test

It was decided to add an Unit test to one of the Llama features that is key to the game loop: Starving to death.
Due to the limited space in the Pen, in order for the player to capture more llamas and earn more money, it is necessary to for them to eventually die. So I decided to create a test to verify if, given enough time, a llama will always die if not fed. The test is meant to ensure that future adjustments on the llama behaviour will not modify the expected behaviour necessary for the game loop.

The consists in add a llama to the scene, and speed up time, until it passes enough time to kill it.
For this test, the time to deplete 1 HP from the llama (HUNGRY_TIMER) is set to 3. The test simulates a time greater than HUNGRY_TIMER * llama.MaxHealth, and verified if the llama is dead (llama.Health <= 0).

The test file can be found in:
Assets/CodingChallenge/Scripts/Tests/PlayMode/LlamaTests.cs