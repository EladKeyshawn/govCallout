from pymongo import MongoClient
import pymongo


class DbManager:
    def __init__(self):
        self.collections = {}

        try:
            self.client = MongoClient('localhost', 27017, serverSelectionTimeoutMS=1)
            self.client.server_info()
            self.db = self.client['test']

        except pymongo.errors.ServerSelectionTimeoutError as err:
            print "problem connecting to server"
            print err

    def get_authorities(self):
        return self.db.authorities

    def get_gov_calls(self):
        return self.db.gov_calls

    def get_collections(self):
        return self.db.test_collection

    def insert_gov_calls(self, govcall_obj):
        govcall_obj.



manager = DbManager()

print manager.get_authorities()
