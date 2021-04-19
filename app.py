from hash import HashTable
with open('dictionnaire.txt') as dictionnaire:
    words = dictionnaire.read()

operation = ''

prompts = {
    'operations': '1: Ajouter\n2: Rechercher\n3: Supprimer\n4: Quitter\n',
    'word': 'Entrez le mot: '
}

def console():

    hash_table = HashTable()

    while True:
        op = input(prompts['operations'])

        if op == '1':
            word = input(prompts['word'])
            hash_table.add(word)
            print(hash_table)
        elif op == '4':
            return

    

def main():
    console()


        

if __name__ == "__main__":
    main()

