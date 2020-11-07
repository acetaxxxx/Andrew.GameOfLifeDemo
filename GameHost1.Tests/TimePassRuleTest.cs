using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameHost1.Tests
{
    [TestClass]
    public class TimePassRuleTest
    {
        /*
        
        Rule(s):
        1. �C�ӲӭM����ت��A - �s���Φ��`�A�C�ӲӭM�P�H�ۨ������ߪ��P��K��ӭM���ͤ��ʡ]�p�ϡA�¦⬰�s���A�զ⬰���`�^
        2. ��e�ӭM���s�����A�ɡA��P�򪺦s���ӭM�C��2�Ӯɡ]���]�t2�ӡ^�A�ӲӭM�ܦ����`���A�C�]�����ͩR�ƶq�}�֡^
        3. ��e�ӭM���s�����A�ɡA��P��2�ө�3�Ӧs���ӭM�ɡA�ӲӭM�O����ˡC
        4. ��e�ӭM���s�����A�ɡA��P�򦳶W�L3�Ӧs���ӭM�ɡA�ӲӭM�ܦ����`���A�C�]�����ͩR�ƶq�L�h�^
        5. ��e�ӭM�����`���A�ɡA��P��3�Ӧs���ӭM�ɡA�ӲӭM�ܦ��s�����A�C�]�����c�ޡ^
        
        */

        [TestMethod("�W�h����2: ��e�ӭM���s�����A�ɡA��P�򪺦s���ӭM�C��2�Ӯɡ]���]�t2�ӡ^�A�ӲӭM�ܦ����`���A�C")]
        public void Rule2_Test()
        {
            // lives: 0
            Assert.IsFalse(GameHost1.Program.TimePassRule(new bool[3, 3]
            {
                { false, false, false },
                { false, true, false },
                { false, false, false}
            }));

            // lives: 1
            Assert.IsFalse(GameHost1.Program.TimePassRule(new bool[3, 3]
            {
                { true, false, false },
                { false, true, false },
                { false, false, false}
            }));

            // lives: 1
            Assert.IsFalse(GameHost1.Program.TimePassRule(new bool[3, 3]
            {
                { false, true, false },
                { false, true, false },
                { false, false, false}
            }));

            // lives: 1
            Assert.IsFalse(GameHost1.Program.TimePassRule(new bool[3, 3]
            {
                { false, false, true },
                { false, true, false },
                { false, false, false}
            }));

            // lives: 1
            Assert.IsFalse(GameHost1.Program.TimePassRule(new bool[3, 3]
            {
                { false, false, false },
                { false, true, true },
                { false, false, false}
            }));

            // lives: 1
            Assert.IsFalse(GameHost1.Program.TimePassRule(new bool[3, 3]
            {
                { false, false, false },
                { false, true, false },
                { false, false, true}
            }));

            // lives: 1
            Assert.IsFalse(GameHost1.Program.TimePassRule(new bool[3, 3]
            {
                { false, false, false },
                { false, true, false },
                { false, true, false}
            }));

            // lives: 1
            Assert.IsFalse(GameHost1.Program.TimePassRule(new bool[3, 3]
            {
                { false, false, false },
                { false, true, false },
                { true, false, false}
            }));

            // lives: 1
            Assert.IsFalse(GameHost1.Program.TimePassRule(new bool[3, 3]
            {
                { false, false, false },
                { true, true, false },
                { false, false, false}
            }));

        }

        [TestMethod("�W�h����3: ��e�ӭM���s�����A�ɡA��P��2�ө�3�Ӧs���ӭM�ɡA�ӲӭM�O�����")]
        public void Rule3_Test()
        {
            // lives: 2
            Assert.IsTrue(GameHost1.Program.TimePassRule(new bool[3, 3]
            {
                { true, true, false },
                { false, true, false },
                { false, false, false}
            }));

            // lives: 3
            Assert.IsTrue(GameHost1.Program.TimePassRule(new bool[3, 3]
            {
                { true, true, true},
                { false, true, false },
                { false, false, false}
            }));
        }

        [TestMethod("�W�h����4: ��e�ӭM���s�����A�ɡA��P�򦳶W�L3�Ӧs���ӭM�ɡA�ӲӭM�ܦ����`���A�C�]�����ͩR�ƶq�L�h�^")]
        public void Rule4_Test()
        {
            // lives: 4
            Assert.IsFalse(GameHost1.Program.TimePassRule(new bool[3, 3]
            {
                { true, true, true },
                { true, true, false },
                { false, false, false}
            }));

            // lives: 5
            Assert.IsFalse(GameHost1.Program.TimePassRule(new bool[3, 3]
            {
                { true, true, true },
                { true, true, true },
                { false, false, false}
            }));

            // lives: 6
            Assert.IsFalse(GameHost1.Program.TimePassRule(new bool[3, 3]
            {
                { true, true, true },
                { true, true, true },
                { true, false, false}
            }));

            // lives: 7
            Assert.IsFalse(GameHost1.Program.TimePassRule(new bool[3, 3]
            {
                { true, true, true },
                { true, true, true },
                { true, true, false}
            }));

            // lives: 8
            Assert.IsFalse(GameHost1.Program.TimePassRule(new bool[3, 3]
            {
                { true, true, true },
                { true, true, true },
                { true, true, true}
            }));


        }

        [TestMethod("�W�h����5: ��e�ӭM�����`���A�ɡA��P��3�Ӧs���ӭM�ɡA�ӲӭM�ܦ��s�����A�C�]�����c�ޡ^")]
        public void Rule5_Test()
        {
            // lives: 0
            Assert.IsFalse(GameHost1.Program.TimePassRule(new bool[3, 3]
            {
                { false, false, false },
                { false, false, false },
                { false, false, false}
            }));

            // lives: 1
            Assert.IsFalse(GameHost1.Program.TimePassRule(new bool[3, 3]
            {
                { true, false, false },
                { false, false, false },
                { false, false, false}
            }));

            // lives: 2
            Assert.IsFalse(GameHost1.Program.TimePassRule(new bool[3, 3]
            {
                { true, true, false },
                { false, false, false },
                { false, false, false}
            }));

            // lives: 3
            Assert.IsTrue(GameHost1.Program.TimePassRule(new bool[3, 3]
            {
                { true, true, true },
                { false, false, false },
                { false, false, false}
            }));

            // lives: 4
            Assert.IsFalse(GameHost1.Program.TimePassRule(new bool[3, 3]
            {
                { true, true, true },
                { true, false, false },
                { false, false, false}
            }));

            // lives: 5
            Assert.IsFalse(GameHost1.Program.TimePassRule(new bool[3, 3]
            {
                { true, true, true },
                { true, false, true },
                { false, false, false}
            }));

            // lives: 6
            Assert.IsFalse(GameHost1.Program.TimePassRule(new bool[3, 3]
            {
                { true, true, true },
                { true, false, true },
                { true, false, false}
            }));

            // lives: 7
            Assert.IsFalse(GameHost1.Program.TimePassRule(new bool[3, 3]
            {
                { true, true, true },
                { true, false, true },
                { true, true, false}
            }));

            // lives: 8
            Assert.IsFalse(GameHost1.Program.TimePassRule(new bool[3, 3]
            {
                { true, true, true },
                { true, false, true },
                { true, true, true}
            }));


        }

    }
}
