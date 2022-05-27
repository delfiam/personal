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
def dictaduradenombres(dictador):
    nombre = 'cata'
    nombre_lista = list('cata')
    dictador_lista = list(dictador)
    cambio = map(nombre_lista, dictador_lista)
    print(cambio) 

holamundo()
uppernom()
dictaduradenombres('jerucho')

# https://itsmycode.com/typeerror-list-object-is-not-callable/#:~:text=The%20most%20common%20scenario%20where,parenthesis%20instead%20of%20square%20brackets.