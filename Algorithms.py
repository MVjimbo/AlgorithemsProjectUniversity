import random


def Piramid(arr,n):
    for i in range((int(n/2)-1),-1,-1):#Проходим по всем родительским узлам
        k=i
        c=arr[i]
        isHeap=False
        if ((not isHeap) and (2*k+1<n)):
            j=2*k+1
            if j+1<n:#Если имеется правый дочерний узел
                if (arr[j]<arr[j+1]):
                    j+=1
            if c>=arr[j]:#Если выполнеяется условие доминирования родительских узлов
                isHeap=True
            else:#иначе меняем значение в родительском узле
                arr[k]=arr[j]
                k=j
        arr[k]=c



def HeapSort(arr):
    #Первый этап алгоритма
    n=len(arr)
    Piramid(arr,n)

    #Второй этап алгоритма пирамидальной сортировки
    arr[n-1],arr[0]=arr[0],arr[n-1]
    for i in range(n-1,1,-1):
        Piramid(arr,i)
        arr[i-1],arr[0]=arr[0],arr[i-1]

def main():
    #Параметры для генерации входных данных: n- кол-во элементов из интервала [a,b]
    n=100
    a=0
    b=100
    arr=[]
    for i in range(n):
        arr.append(random.uniform(a,b))

    #print("Before") #Вывод массива ДО
    #for i in arr:print("%.2f" % i,end="  ")

    HeapSort(arr)

    #print("After") #Вывод массива ПОСЛЕ
    #for i in arr:print("%.2f" % i,end="  ")

    #Проверка на отсортированность
    isSort=True
    for i in range(0,n-1):
        if (arr[i]>=arr[i+1]):
            isSort=False
            break

    if (not isSort):
        print("Not sorted")
    else:
        print("Sorted")

if (__name__=="__main__"):
    main()

