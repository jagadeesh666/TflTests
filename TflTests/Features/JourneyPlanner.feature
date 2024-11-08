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
    And I click Plan Journey on TFL homepage
    Then I should see journey results
    And I should see walking and cycling times on journey results screen

@smoke
Scenario: Verify Edit preferences and select routh with least walking distance
    Given I am on the TFL homepage
    And I Accept allow all cookies
    When I enter "Leicester Square Underground Station" in the From field
    And I enter "Covent Garden Underground Station" in the To field
    And I click Plan Journey on TFL homepage
    Then I should see journey results
    And I should see walking and cycling times on journey results screen
    And I select Edit preferences on journey results screen
    And I select route with least walking distance on journey results screen
    And I click update journey button on journey results screen

@smoke
Scenario: Verify view details
    Given I am on the TFL homepage
    And I Accept allow all cookies
    When I enter "Leicester Square Underground Station" in the From field
    And I enter "Covent Garden Underground Station" in the To field
    And I click Plan Journey on TFL homepage
    Then I should see journey results
    And I should see walking and cycling times on journey results screen
    And I select Edit preferences on journey results screen
    And I select route with least walking distance on journey results screen
    And I click update journey button on journey results screen
    And I view details on journey results screen

@Smoke
Scenario: Verify error message for invalid location
  Given I am on the TFL homepage
  And I Accept allow all cookies
  When I click Plan Journey on TFL homepage
  Then I should see From error message "The From field is required." on TFL homepage
  Then I should see To error message "The To field is required." on TFL homepage

 @Smoke
Scenario: Verify unable to plan journey when no locations entered
  Given I am on the TFL homepage
  And I Accept allow all cookies
  When I enter "_" in the From field
  And I enter "_" in the To field
  And I click Plan Journey on TFL homepage
  Then I should see an error message on journey results screen

@Regression
Scenario Outline: Verify journey times for different stations
  Given I am on the TFL homepage
    And I Accept allow all cookies
  When I enter "<FromStation>" in the From field
  And I enter "<ToStation>" in the To field
  And I click Plan Journey on TFL homepage
  Then I should see walking and cycling times on journey results screen

  Examples:
    | FromStation                           | ToStation                          |
    | Leicester Square Underground Station  | Covent Garden Underground Station  |
    | Piccadilly Circus Underground Station | Oxford Circus Underground Station  |

@Performance @ignore
Scenario: Verify journey planner response time
  Given I am on the TFL homepage
  And I Accept allow all cookies
  When I enter "Leicester Square Underground Station" in the From field
  And I enter "Covent Garden Underground Station" in the To field
  And I click Plan Journey on TFL homepage
  Then the journey results should load within 10 seconds on journey results screen
