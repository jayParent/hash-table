class HashTable:
    """Table a addressage dispersee avec resolution de collision par chainage simple"""
    def __init__(self, buffer, n):
        self.buffer = buffer
        self.n = n
    
    def __str__(self):
        return super().__str__()
    
    def hash(self):
        # Not implemented
        pass

    def add(self):
        # Not implemented
        pass
    
    def find(self):
        # Not implemented
        pass
    
    def remove(self):
        # Not implemented
        pass
    

ht = HashTable([], 10)
print(ht)
