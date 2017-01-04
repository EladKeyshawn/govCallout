import json
from pymongo import MongoClient
import pymongo
import datetime

from scraper.GovCall import GovCall


class ComplexEncoder(json.JSONEncoder):
    def default(self, obj):
        if hasattr(obj, 'reprJSON'):
            return obj.reprJSON()
        else:
            return json.JSONEncoder.default(self, obj)


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
        # json_obj = json.dumps(govcall_obj.toJSON(), cls=ComplexEncoder)
        self.db.gov_calls.insert_one(govcall_obj.__dict__)

    def get_gov_collection_data(self):
        return self.db.gov_calls.find({})


print datetime.date(2010, 5, 1).strftime("%Y-%m-%d")
manager = DbManager()

gov_call_obj = GovCall(1, 'smart classes', 'education', 50000, 1000, 'poor',
                       datetime.date(2010, 5, 1).strftime("%Y-%m-%d"))


manager.insert_gov_calls(gov_call_obj)

for doc in manager.get_gov_collection_data():
    print doc
