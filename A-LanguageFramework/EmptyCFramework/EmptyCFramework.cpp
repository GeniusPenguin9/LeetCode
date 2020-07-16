// EmptyCFramework.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include <stdlib.h>
#include <string.h>
int findTheLongestSubstring(char* s) {
    char* start = s;
    char* end= start+ 500000;

    int max = 0;
    while (1)
    {
        if (*start == '\0' || end-start < max)
            break;
        char* now = start;
        int count[] = { 0,0,0,0,0 };

        while (1)
        {
            if (*now == '\0')
            {
                end = now;
                break;
            }
            else if (*now == 'a')
                count[0] += 1;
            else if (*now == 'e')
                count[1] += 1;
            else if (*now == 'i')
                count[2] += 1;
            else if (*now == 'o')
                count[3] += 1;
            else if (*now == 'u')
                count[4] += 1;

            if (count[0] % 2 == 0 && count[1] % 2 == 0 && count[2] % 2 == 0 && count[3] % 2 == 0 && count[4] % 2 == 0)
                max = now - start + 1 > max ? now - start + 1 : max;

            now++;
        }
        start++;
    }
    return max;
}

int numOfMinutes(int n, int headID, int* manager, int managerSize, int* informTime, int informTimeSize) {
    if (n <= 0)
        return 0;
    int* engineerID = (int*)malloc(n);
    memset(engineerID, 0, n);
    for (int i = 0; i < n; i++)
    {
        if (*(manager + i) == headID)
            *(engineerID + i) = 1;
    }
    int time = 0;
    for (int i = 0; i < n; i++)
    {
        if (*(engineerID + i) == 1)
        {
            int time_temp = *(informTime + headID) + numOfMinutes(n, i,manager, managerSize, informTime, informTimeSize);
            if (time_temp > time)
                time = time_temp;
        }
    }
    free(engineerID);
    return time;
}

int main()
{
    //char str[] = "eleetminicoworoep";
    //int res13 = findTheLongestSubstring(str);

    //char str2[] = "leetcodeisgreat";
    //int res5 = findTheLongestSubstring(str2);

    //char str3[] = "bcbcbc";
    //int res6 = findTheLongestSubstring(str3);
}