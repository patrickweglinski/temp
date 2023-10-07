import re
import string
import pandas
from sklearn.tree import DecisionTreeClassifier
from sklearn.ensemble import RandomForestClassifier
from sklearn.datasets import make_classification




df = pandas.read_csv("census-income.csv")
print(df)
# See PyCharm help at https://www.jetbrains.com/help/pycharm/
classes = df.iloc[:,-1]
print(classes)


file = open("Census Feature Descriptions.txt")
# for row in file:
#     print(row)

mapping = {}

for line in file:
    line = re.sub('\t+','=', line)
    (key, val) = line.split("=")
    mapping[(key)] = val


mapping = d_swap = {v: k for k, v in mapping.items()}


for item in df.columns:
    temp = item
    temp = temp + '\n'
    if temp in mapping.keys():
        df.rename(columns={temp: mapping[temp]})


print(df)

