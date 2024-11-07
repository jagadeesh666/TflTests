@regression
Feature: Journey Planner
As a TFL website user
I want to plan my journey
So that I can see travel options between two locations

@smoke
Scenario: Verify valid journey between Leicester Square and Covent Garden
    Given I am on the TFL homepage
    And I Accept allow all cookies
    When I enter "Leicester Square Underground Station" in the From field
    And I enter "Covent Garden Underground Station" in the To field
    And I click Plan Journey
    Then I should see journey results
    And I should see walking and cycling times on journey results screen

@smoke
Scenario: Verify Edit preferences and select routh with least walking distance
    Given I am on the TFL homepage
    And I Accept allow all cookies
    When I enter "Leicester Square Underground Station" in the From field
    And I enter "Covent Garden Underground Station" in the To field
    And I click Plan Journey
    Then I should see journey results
    And I should see walking and cycling times on journey results screen
    And I select Edit preferences on journey results screen
    And I select route with least walking distance on journey results screen
    And I click update journey button on journey results screen

 @Performance
Scenario: Verify journey planner response time
  Given I am on the TFL homepage
  When I enter "Leicester Square" in the From field
  And I enter "Covent Garden" in the To field
  And I click Plan Journey
  Then the journey results should load within 5 seconds on journey results screen

@Smoke
Scenario: Verify error message for invalid location
  Given I am on the TFL homepage
  When I enter "XXXXX" in the From field
  And I enter "Covent Garden" in the To field
  And I click Plan Journey on TFL homepage
  Then I should see an error message on TFL homepage

@Regression
Scenario Outline: Verify journey times for different stations
  Given I am on the TFL homepage
  When I enter "<FromStation>" in the From field
  And I enter "<ToStation>" in the To field
  And I click Plan Journey on TFL homepage
  Then I should see walking and cycling times on journey results screen

  Examples:
    | FromStation      | ToStation        |
    | Leicester Square | Covent Garden    |
    | Piccadilly Circus| Oxford Circus    |
    | Victoria        | Liverpool Street  |
