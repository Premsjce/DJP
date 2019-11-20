using System;

namespace LeetCode
{
    public class LinkedListDriver
    {
        public static void Driver()
        {

            var numOne = new ListNode(2);
            numOne.next = new ListNode(4);
            numOne.next.next = new ListNode(3);

            var numTwo = new ListNode(5);
            numTwo.next = new ListNode(6);
            numTwo.next.next = new ListNode(4);
            //numTwo.next.next = new ListNode(9);
            //numTwo.next.next.next = new ListNode(9);
            //numTwo.next.next.next.next = new ListNode(9);
            //numTwo.next.next.next.next.next = new ListNode(9);
            //numTwo.next.next.next.next.next.next = new ListNode(9);
            //numTwo.next.next.next.next.next.next.next = new ListNode(9);
            //numTwo.next.next.next.next.next.next.next.next = new ListNode(9);
            //numTwo.next.next.next.next.next.next.next.next.next = new ListNode(9);
            //numTwo.next.next.next.next.next.next.next.next.next.next = new ListNode(9);


            var revAdd = new RevereseLinkedListAdd2Numbers();
            //var result = revAdd.AddTwoNumbers(numOne, numTwo);
            var result = revAdd.AddNumbersDirectly(numOne, numTwo);
            Console.WriteLine(result.val);
        }
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class RevereseLinkedListAdd2Numbers
    {
        public ListNode AddNumbersDirectly(ListNode listNodeOne, ListNode listNodeTwo)
        {
            ListNode prev = null, temp = null, res= null;
            int carry = 0;

            while(listNodeOne != null || listNodeTwo != null)
            {
                var sum = carry + (listNodeOne == null ? 0 : listNodeOne.val) + (listNodeTwo == null ? 0 : listNodeTwo.val);
                carry = (sum >= 10) ? 1 : 0;
                sum = sum % 10;
                temp = new ListNode(sum);

                if (res == null)
                    res = temp;
                else
                    prev.next = temp;

                prev = temp;

                if (listNodeOne != null)
                    listNodeOne = listNodeOne.next;
                if (listNodeTwo != null)
                    listNodeTwo = listNodeTwo.next;
            }

            if (carry > 0)
                temp.next = new ListNode(carry);
            return res;
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            l1 = ReverseList(l1);
            l2 = ReverseList(l2);

            var num1 = GetNumber(l1) ;
            var num2 = GetNumber(l2);
            var result = num1 + num2;

            if (result == 0)
                return new ListNode(0);

            ListNode previous = null, current = null, next = null;
            while (result != 0)
            {
                current = new ListNode((int)(result % 10));
                next = current.next;
                current.next = previous;
                previous = current;
                current = next;
                result = ((int)result) / 10;
            }

            return ReverseList(previous);
        }

        private double GetNumber(ListNode listNode)
        {
            double result = 0;
            while (listNode != null)
            {
                result *= 10;
                result += listNode.val;
                listNode = listNode.next;
            }
            return result;
        }

        private ListNode ReverseList(ListNode listNode)
        {
            ListNode previous = null, current = listNode, next = null;
            while (current != null)
            {
                next = current.next;
                current.next = previous;
                previous = current;
                current = next;
            }

            return previous;
        }
    }
}

