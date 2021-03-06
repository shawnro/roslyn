﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using Microsoft.VisualStudio.IntegrationTest.Utilities;
using Microsoft.VisualStudio.IntegrationTest.Utilities.Input;
using Xunit;

namespace Roslyn.VisualStudio.IntegrationTests.CSharp
{
    [Collection(nameof(SharedIntegrationHostFixture))]
    public class CSharpInteractiveBoxSelection : AbstractInteractiveWindowTest
    {
        public CSharpInteractiveBoxSelection(VisualStudioInstanceFactory instanceFactory)
            : base(instanceFactory)
        {
            VisualStudio.InteractiveWindow.SubmitText("#cls");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                VisualStudio.ExecuteCommand(WellKnownCommandNames.Edit_SelectionCancel);
            }

            base.Dispose(disposing);
        }

        [Fact]
        public void TopLeftBottomRightPromptToSymbol()
        {
            InsertInputWithXAtLeft();

            VisualStudio.InteractiveWindow.PlaceCaret(">", 1);
            VisualStudio.InteractiveWindow.PlaceCaret("x", 0, extendSelection: true, selectBlock: true);
            VisualStudio.SendKeys.Send("__", VirtualKey.Escape, "|");

            VisualStudio.InteractiveWindow.Verify.LastReplInput(@"__234567890ABCDEF
__234567890ABCDEF
__234567890ABCDEF
__234567890ABCDEF
__234567890ABCDEF
__234567890ABCDEF
__|234567890ABCDEF
1234567890ABCDEF");
        }

        [Fact]
        public void BottomRightTopLeftPromptToSymbol()
        {
            InsertInputWithXAtLeft();
            VisualStudio.InteractiveWindow.PlaceCaret("x", 0);
            VisualStudio.InteractiveWindow.PlaceCaret(">", 1, extendSelection: true, selectBlock: true);
            VisualStudio.SendKeys.Send("__", VirtualKey.Escape, "|");

            VisualStudio.InteractiveWindow.Verify.LastReplInput(@"__|234567890ABCDEF
__234567890ABCDEF
__234567890ABCDEF
__234567890ABCDEF
__234567890ABCDEF
__234567890ABCDEF
__234567890ABCDEF
1234567890ABCDEF");
        }

        [Fact]
        public void TopRightBottomLeftPromptToSymbol()
        {
            InsertInputWithXAtLeft();
            VisualStudio.InteractiveWindow.PlaceCaret(">", 3);
            VisualStudio.InteractiveWindow.PlaceCaret("x", -2, extendSelection: true, selectBlock: true);
            VisualStudio.SendKeys.Send("__", VirtualKey.Escape, "|");

            VisualStudio.InteractiveWindow.Verify.LastReplInput(@"__234567890ABCDEF
__234567890ABCDEF
__234567890ABCDEF
__234567890ABCDEF
__234567890ABCDEF
__234567890ABCDEF
__|234567890ABCDEF
1234567890ABCDEF");
        }

        [Fact]
        public void BottomLeftTopRightPromptToSymbol()
        {
            InsertInputWithXAtLeft();
            VisualStudio.InteractiveWindow.PlaceCaret("x", -2);
            VisualStudio.InteractiveWindow.PlaceCaret(">", 3, extendSelection: true, selectBlock: true);
            VisualStudio.SendKeys.Send("__", VirtualKey.Escape, "|");

            VisualStudio.InteractiveWindow.Verify.LastReplInput(@"__|234567890ABCDEF
__234567890ABCDEF
__234567890ABCDEF
__234567890ABCDEF
__234567890ABCDEF
__234567890ABCDEF
__234567890ABCDEF
1234567890ABCDEF");
        }

        [Fact]
        public void TopLeftBottomRightSymbolToSymbol()
        {
            InsertInputWithSAndEAtLeft();
            VisualStudio.InteractiveWindow.PlaceCaret("s", -1);
            VisualStudio.InteractiveWindow.PlaceCaret("e", 1, extendSelection: true, selectBlock: true);
            VisualStudio.SendKeys.Send("__", VirtualKey.Escape, "|");

            VisualStudio.InteractiveWindow.Verify.LastReplInput(@"1234567890ABCDEF
1234567890ABCDEF
__234567890ABCDEF
__234567890ABCDEF
__234567890ABCDEF
__234567890ABCDEF
__|234567890ABCDEF
1234567890ABCDEF");
        }

        [Fact]
        public void BottomRightTopLeftSymbolToSymbol()
        {
            InsertInputWithSAndEAtLeft();
            VisualStudio.InteractiveWindow.PlaceCaret("e", 1);
            VisualStudio.InteractiveWindow.PlaceCaret("s", -1, extendSelection: true, selectBlock: true);
            VisualStudio.SendKeys.Send("__", VirtualKey.Escape, "|");

            VisualStudio.InteractiveWindow.Verify.LastReplInput(@"1234567890ABCDEF
1234567890ABCDEF
__|234567890ABCDEF
__234567890ABCDEF
__234567890ABCDEF
__234567890ABCDEF
__234567890ABCDEF
1234567890ABCDEF");
        }

        [Fact]
        public void TopRightBottomLeftSymbolToSymbol()
        {
            InsertInputWithSAndEAtLeft();
            VisualStudio.InteractiveWindow.PlaceCaret("s", 1);
            VisualStudio.InteractiveWindow.PlaceCaret("e", -1, extendSelection: true, selectBlock: true);
            VisualStudio.SendKeys.Send("__", VirtualKey.Escape, "|");

            VisualStudio.InteractiveWindow.Verify.LastReplInput(@"1234567890ABCDEF
1234567890ABCDEF
__234567890ABCDEF
__234567890ABCDEF
__234567890ABCDEF
__234567890ABCDEF
__|234567890ABCDEF
1234567890ABCDEF");
        }


        [Fact]
        public void BottomLeftTopRightSymbolToSymbol()
        {
            InsertInputWithSAndEAtLeft();
            VisualStudio.InteractiveWindow.PlaceCaret("e", -1);
            VisualStudio.InteractiveWindow.PlaceCaret("s", 1, extendSelection: true, selectBlock: true);
            VisualStudio.SendKeys.Send("__", VirtualKey.Escape, "|");

            VisualStudio.InteractiveWindow.Verify.LastReplInput(@"1234567890ABCDEF
1234567890ABCDEF
__|234567890ABCDEF
__234567890ABCDEF
__234567890ABCDEF
__234567890ABCDEF
__234567890ABCDEF
1234567890ABCDEF");
        }

        [Fact]
        public void TopLeftBottomRightSelection1()
        {
            InsertInputWithSAndEAtLeft();
            VisualStudio.InteractiveWindow.PlaceCaret("s", -3);
            VisualStudio.InteractiveWindow.PlaceCaret("e", 2, extendSelection: true, selectBlock: true);
            VisualStudio.SendKeys.Send("_");

            VisualStudio.InteractiveWindow.Verify.LastReplInput(@"1234567890ABCDEF
1234567890ABCDEF
_34567890ABCDEF
_34567890ABCDEF
_34567890ABCDEF
_34567890ABCDEF
_34567890ABCDEF
1234567890ABCDEF");
        }

        [Fact]
        public void TopLeftBottomRightSelection2()
        {
            InsertInputWithSAndEAtLeft();
            VisualStudio.InteractiveWindow.PlaceCaret("e", -2);
            VisualStudio.InteractiveWindow.PlaceCaret("s", -3, extendSelection: true, selectBlock: true);
            VisualStudio.SendKeys.Send("_");

            VerifyOriginalCodeWithSAndEAtLeft();
        }

        [Fact]
        public void TopRightBottomLeftSelection()
        {
            InsertInputWithSAndEAtLeft();
            VisualStudio.InteractiveWindow.PlaceCaret("s", -2);
            VisualStudio.InteractiveWindow.PlaceCaret("e", -3, extendSelection: true, selectBlock: true);
            VisualStudio.SendKeys.Send("_");

            VerifyOriginalCodeWithSAndEAtLeft();
        }

        [Fact]
        public void BottomLeftTopRightSelection()
        {
            InsertInputWithSAndEAtLeft();
            VisualStudio.InteractiveWindow.PlaceCaret("e", -3);
            VisualStudio.InteractiveWindow.PlaceCaret("s", -2, extendSelection: true, selectBlock: true);
            VisualStudio.SendKeys.Send("_");

            VerifyOriginalCodeWithSAndEAtLeft();
        }

        [Fact]
        public void SelectionTouchingSubmissionBuffer()
        {
            InsertInputWithSAndEAtLeft();
            VisualStudio.InteractiveWindow.PlaceCaret("s", -2);
            VisualStudio.InteractiveWindow.PlaceCaret("e", -1, extendSelection: true, selectBlock: true);
            VisualStudio.SendKeys.Send("__");

            VisualStudio.InteractiveWindow.Verify.LastReplInput(@"1234567890ABCDEF
1234567890ABCDEF
__s234567890ABCDEF
__1234567890ABCDEF
__1234567890ABCDEF
__1234567890ABCDEF
__e234567890ABCDEF
1234567890ABCDEF");
        }

        [Fact]
        public void PrimaryPromptLongerThanSecondaryZeroWidthNextToPromptSelection()
        {
            InsertInputWithSAndEAtLeft();
            VisualStudio.InteractiveWindow.PlaceCaret("s", -1);
            VisualStudio.InteractiveWindow.PlaceCaret("e", -1, extendSelection: true, selectBlock: true);
            VisualStudio.SendKeys.Send("__");

            VisualStudio.InteractiveWindow.Verify.LastReplInput(@"1234567890ABCDEF
1234567890ABCDEF
__s234567890ABCDEF
__1234567890ABCDEF
__1234567890ABCDEF
__1234567890ABCDEF
__e234567890ABCDEF
1234567890ABCDEF");
        }

        [Fact]
        public void Backspace()
        {
            InsertInputWithSAndEInTheMiddle();
            VisualStudio.InteractiveWindow.PlaceCaret("s", -1);
            VisualStudio.InteractiveWindow.PlaceCaret("e", 0, extendSelection: true, selectBlock: true);
            VisualStudio.SendKeys.Send(VirtualKey.Backspace, VirtualKey.Backspace);

            VisualStudio.InteractiveWindow.Verify.LastReplInput(@"1CDEF
1CDEF
1CDEF
1CDEF
1CDEF
1CDEF
1CDEF
1234567890ABCDEF");
        }

        [Fact]
        public void BackspaceBehavesLikeDelete()
        {
            InsertInputWithEInTheMiddle();
            VisualStudio.InteractiveWindow.PlaceCaret(">", 0);
            VisualStudio.InteractiveWindow.PlaceCaret("e", 0, extendSelection: true, selectBlock: true);
            VisualStudio.SendKeys.Send(VirtualKey.Backspace, VirtualKey.Backspace);

            VisualStudio.InteractiveWindow.Verify.LastReplInput(@"CDEF
CDEF
CDEF
CDEF
CDEF
CDEF
CDEF
1234567890ABCDEF");
        }

        [Fact]
        public void LeftToRightReversedBackspace()
        {
            VisualStudio.InteractiveWindow.InsertCode("1234567890ABCDEF");
            VisualStudio.InteractiveWindow.PlaceCaret("2", -5);
            VisualStudio.InteractiveWindow.PlaceCaret(">", 8, extendSelection: true, selectBlock: true);
            VisualStudio.SendKeys.Send(VirtualKey.Backspace);

            VisualStudio.InteractiveWindow.Verify.LastReplInput(@"7890ABCDEF");
        }

        [Fact]
        public void LeftToRightReversedDelete()
        {
            VisualStudio.InteractiveWindow.InsertCode("1234567890ABCDEF");
            VisualStudio.InteractiveWindow.PlaceCaret("1", -1);
            VisualStudio.InteractiveWindow.PlaceCaret(">", 5, extendSelection: true, selectBlock: true);
            VisualStudio.SendKeys.Send(VirtualKey.Delete);

            VisualStudio.InteractiveWindow.Verify.LastReplInput(@"4567890ABCDEF");
        }

        [Fact]
        public void LeftToRightReversedTypeCharacter()
        {
            VisualStudio.InteractiveWindow.InsertCode("1234567890ABCDEF");
            VisualStudio.InteractiveWindow.PlaceCaret("1", -1);
            VisualStudio.InteractiveWindow.PlaceCaret(">", 5, extendSelection: true, selectBlock: true);
            VisualStudio.SendKeys.Send("__");

            VisualStudio.InteractiveWindow.Verify.LastReplInput(@"__4567890ABCDEF");
        }

        private void InsertInputWithXAtLeft()
        {
            VisualStudio.InteractiveWindow.InsertCode(@"1234567890ABCDEF
1234567890ABCDEF
1234567890ABCDEF
1234567890ABCDEF
1234567890ABCDEF
1234567890ABCDEF
x234567890ABCDEF
1234567890ABCDEF");
        }

        private void InsertInputWithSAndEAtLeft()
        {
            VisualStudio.InteractiveWindow.InsertCode(@"1234567890ABCDEF
1234567890ABCDEF
s234567890ABCDEF
1234567890ABCDEF
1234567890ABCDEF
1234567890ABCDEF
e234567890ABCDEF
1234567890ABCDEF");
        }

        private void InsertInputWithSAndEInTheMiddle()
        {
            VisualStudio.InteractiveWindow.InsertCode(@"12s4567890ABCDEF
1234567890ABCDEF
1234567890ABCDEF
1234567890ABCDEF
1234567890ABCDEF
1234567890ABCDEF
1234567890AeCDEF
1234567890ABCDEF");
        }

        private void InsertInputWithEInTheMiddle()
        {
            VisualStudio.InteractiveWindow.InsertCode(@"1234567890ABCDEF
1234567890ABCDEF
1234567890ABCDEF
1234567890ABCDEF
1234567890ABCDEF
1234567890ABCDEF
1234567890AeCDEF
1234567890ABCDEF");
        }

        private void VerifyOriginalCodeWithSAndEAtLeft()
        {
            VisualStudio.InteractiveWindow.Verify.LastReplInput(@"1234567890ABCDEF
1234567890ABCDEF
s234567890ABCDEF
1234567890ABCDEF
1234567890ABCDEF
1234567890ABCDEF
e234567890ABCDEF
1234567890ABCDEF");
        }
    }
}
