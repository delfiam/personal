# https://pynative.com/python-exercises-with-solutions/
# https://pynative.com/python-set-exercise-with-solutions/#h-exercise-1-add-a-list-of-elements-to-a-set
# https://pynative.com/python-list-exercise-with-solutions/

# ej 1
# Given two integer numbers return their 
# product only if the product is equal to or 
# lower than 1000, else return their sum.
def ejuno (num1, num2):
    producto = num1*num2
    suma = num1 + num2
    if (producto <= 1000):
        print("1) El producto es", producto)
    else:
        print("1) La suma es", suma)

# Exercise 1: Add a list of elements to a set
# Given a Python list, Write a program to add all its elements into a given set.
def ejdos ():
    sample_set = {"Yellow", "Orange", "Black"}
    sample_list = ["Blue", "Green", "Red"]
    sample_set.update(sample_list)
    print("2)", sample_set)

# Exercise 2: Return a new set 
# of identical items from two sets
def ejtres ():
    set1 = {10, 20, 30, 40, 50}
    set2 = {30, 40, 50, 60, 70}
    ambos = set1.intersection(set2)
    print("3)", ambos)

# Exercise 2: Concatenate two lists index-wise
# Write a program to add two lists index-wise. 
# Create a new list that contains the 0th index item 
# from both the list, then the 1st index item, and so on till the last element. any leftover items will get added at the end of the new list.

def ejcuatro():
    list1 = ["M", "na", "i", "Ke"]
    list2 = ["y", "me", "s", "lly"]
    ambos = zip(list1, list2)
    print("4)", tuple(ambos))

ejuno(100, 50)
ejdos()
ejtres()
ejcuatro()