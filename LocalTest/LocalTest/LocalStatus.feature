Feature: Local Connected Status

Scenario: Checking Local connection Status
Given I am on the google page
When I navigate to http://localhost:45691/check
Then I see status as up and running