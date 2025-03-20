using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Patient
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public Patient(string name, int age)
    {
        Name = name;
        Age = age;
    }
}
public class Google
{

    public static int maxAllotedRoom = 0;
    public static void Main(String[] args)
    {
       callAppointments();
    }

    private static void callAppointments()
    {
        int[] appointmentTimes = { 1, 3, 5, 8, 19 }; // assuming it is already sorted
        int[] durations = { 20, 3, 2, 9, 1 };
        int rooms = 2;
        // room no 1 for oth index
        // room no 2 for 1th index
        // room no 3 for 2nd index
        // room no 2 for 3rd index
        // room no 2 for 4th index
        int expectedRoomNo = 2;
        int expectedFrequency = 3;
        int freq = getMaxFrequency1(appointmentTimes, durations, rooms);
        Console.WriteLine(freq);
        Console.WriteLine("max no of times alloted room is room no " + maxAllotedRoom + " with frequency " + freq);
    }

    public static int getMaxFrequency1(int[] appointmentTimes, int[] durations, int totalRooms)
    {
        // two min heap solution order NLOgK
        int max = int.MinValue;
        Dictionary<int, int> frequencyMap = new Dictionary<int, int>(); // <roomNo,Freq>

        PriorityQueue<int, int> roomEndTimePQ = new PriorityQueue<int, int>(); // roomNo, EndTime #TODO REVERSE?
        PriorityQueue<int, int> availableRoomsPQ = new PriorityQueue<int, int>(); // <roomNo,roomNo Priority> #TODO REVERSE?
        int i, j, k;
        for (int ii = 1; ii <= totalRooms; ii++)
            availableRoomsPQ.Enqueue(ii, ii);// O(Klogk) to build heap (k is total no of room)

        for (int ii = 0; ii < appointmentTimes.Length; ii++)
        { //O(N)
            int val, priorityofLastRoom;
            roomEndTimePQ.TryPeek(out val, out priorityofLastRoom); // EndTimeOfRoomAtTop
            while (roomEndTimePQ.Count > 0 && priorityofLastRoom < appointmentTimes[ii])
            {
                i = roomEndTimePQ.Dequeue();
                availableRoomsPQ.Enqueue(i,i);
                roomEndTimePQ.TryPeek(out val, out priorityofLastRoom); // EndTimeOfRoomAtTop
            } // this while loop runs Atmost N times during whole iteration so ignore this
            int startTime = appointmentTimes[ii];
            if (availableRoomsPQ.Count == 0)
            { // special case , all room allotted and no one is free
                j = roomEndTimePQ.Peek();
                availableRoomsPQ.Enqueue(j,j);
                k = roomEndTimePQ.Dequeue();// deallocation in future
                startTime = k;// allocation in future
            }
            int roomNo = availableRoomsPQ.Dequeue();
            int value = 0;
            int freq = 0;
            if (frequencyMap.TryGetValue(roomNo, out value))
            {
                freq = value;
            }
            frequencyMap[roomNo] = freq + 1;
           
        if (frequencyMap[roomNo] > max)
                maxAllotedRoom = roomNo;
            max = Math.Max(max, frequencyMap[roomNo]); // O(1)
            int endTime = startTime + durations[ii];

            roomEndTimePQ.Enqueue(roomNo, endTime);// O(log k) to heapify (max no of entry in heaps will be k i.e total rooms)

        }
        return max;
    }

    public static int getMaxFrequency(int[] appointmentTimes, int[] durations, int totalRooms)
    {   // two min heap solution

        // order NLOgK

        // two min heap solution order NLOgK

        int max = int.MinValue;

        Dictionary<int, int> frequencyMap = new Dictionary<int, int>(); // <roomNo,Freq>

        PriorityQueue<int, int> roomEndTimePQ = new PriorityQueue<int, int>(); // <roomNo,EndTime>

        PriorityQueue<int, int> availableRoomsPQ = new PriorityQueue<int, int>(); // <roomNo,roomNo Priority> // Check for Priority

        for (int i = 1; i <= totalRooms; i++)

            availableRoomsPQ.Enqueue(i, i);// O(Klogk) to build heap (k is total no of room)

        for (int i = 0; i < appointmentTimes.Length; i++)
        { // O(N)

            while (roomEndTimePQ.Count > 0 && roomEndTimePQ.Peek() < appointmentTimes[i])
            {
                var rret = roomEndTimePQ.Dequeue();
                availableRoomsPQ.Enqueue(rret, rret);
            } // this while loop runs Atmost N times during whole iteration so ignore this

            int startTime = appointmentTimes[i];

            if (availableRoomsPQ.Count == 0)
            { // special case , all room allotted and no one is free

                var aroom = roomEndTimePQ.Peek(); // TODO get priority

                 availableRoomsPQ.Enqueue(aroom, aroom); // deallocation in future

                startTime = roomEndTimePQ.Dequeue(); // allocation in future

            }

            int roomNo = availableRoomsPQ.Dequeue();

            int freq = frequencyMap[roomNo];

            frequencyMap[roomNo] = freq + 1;

            if (frequencyMap[roomNo] > max)

                maxAllotedRoom = roomNo;

            max = Math.Max(max, frequencyMap[roomNo]); // O(1)

            int endTime = startTime + durations[i];

            roomEndTimePQ.Enqueue(roomNo, endTime);// O(log k) to heapify (max no of entry in

            // heaps will be k i.e total rooms)

        }

        return max;

    }

    // worst case O(Nlogk)

}