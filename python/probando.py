# print en diferentes tipos 
def holamundo():
    muchosholas = "hola mundo:)" * 10
    print(muchosholas)

# upper
def uppernom():
    mnombres = ['delfi', 'jere', 'cata']
    nombremayus = []

    for nombre in mnombres:
        nombre_ = nombre.upper()
        nombremayus.append(nombre_)
        print(nombremayus)

# map
def cambiodenombre(nombre2):
    nombre = 'cata'
    cambio = map(nombre, nombre2)
    print(cambio) 

holamundo()
uppernom()
cambiodenombre('aaa')
# https://itsmycode.com/typeerror-list-object-is-not-callable/#:~:text=The%20most%20common%20scenario%20where,parenthesis%20instead%20of%20square%20brackets.
