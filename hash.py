class HashTable:
    """Table a addressage dispersee avec resolution de collision par chainage simple"""
    def __init__(self):
        self.table = []

    def __str__(self):
        return f'Hash Table: {len(self.table)} items.'
    
    def hash(self, buffer, n):

        #! Hash function implementation
        h = 2**63

        self.table.append(h)

    def add(self, word):
        self.table.append(word)
    
    def find(self):
        # Not implemented
        pass
    
    def remove(self):
        # Not implemented
        pass
