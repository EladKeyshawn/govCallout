class GovCall:
    def __init__(self, id, subject, office, finance_help, match_amount, audience, last_date):
        self.kolkoreID = id
        self.subject = subject
        self.initiatorOffice = office
        self.financialAidAmount = finance_help
        self.matchingAmount = match_amount
        self.targetAudience = audience
        self.lastHandingTime = last_date

    def toJSON(self):
        return dict(id=self.kolkoreID, subject=self.subject, office=self.initiatorOffice,
                    financial_aid=self.financialAidAmount, match_amount=self.matchingAmount,
                    audience=self.targetAudience, last_handling_date=self.lastHandingTime)
