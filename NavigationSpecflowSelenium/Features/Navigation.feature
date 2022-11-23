Feature: Navigation

A short summary of the feature

@Navigation
Scenario: Basic Website Navigation
	Given I navigate to "https://www.teaminternational.com/" and validate the page title has "TEAM International"
	And I navigate through main page section by section and back to main page
	Then I hover on "Logistics & Transportation" and see the text "Build your end-to-end digital" being displayed in description
	Then I hover on "Oil & Gas" and see the text "Harness digital solutions" being displayed in description
	Then I hover on "Telecom" and see the text "Empower your organization" being displayed in description
	Then I Click on "Logistics & Transportation" on main page and validate i navigated to the correct page
	And I Click on Main page link
	And I Click on "Oil & Gas" on main page and validate i navigated to the correct page
	And I Click on Main page link
	And I Click on "Telecom" on main page and validate i navigated to the correct page
	And I Click on Main page link
	And I Click on "Technology & Innovation " on main page and validate i navigated to the correct page
	And I Click on Main page link
	And I Click on "Financial Services" on main page and validate i navigated to the correct page
	And I Click on Main page link
	And I Click on "Healthcare & Life Sciences" on main page and validate i navigated to the correct page
	And I Click on Main page link
	And I Click on "Travel & Hospitality" on main page and validate i navigated to the correct page
	And I Click on Main page link
	And I Click on "Retail & Ecommerce" on main page and validate i navigated to the correct page
	And I Click on Main page link
	And I Click on "Digital Marketing" on main page and validate i navigated to the correct page
	And I Click on Main page link
	Then I navigate to Section "2" and Validate I am in "Innovative IT Software Services" page
	And I Hover on section 2 "Automation Services" banner and see text "Leverage robotic process" in description
	And I Hover on section 2 "Managed IT Services" banner and see text "Rapidly evolving technology" in description
	Then I Click on "Automation Services" on Innovative IT page and validate i navigated to the correct page
	And I Click on Main page link
	Then I navigate to Section "2" and Validate I am in "Innovative IT Software Services" page
	Then I Click on "Managed IT Services" on Innovative IT page and validate i navigated to the correct page
	And I Click on Main page link
	Then I navigate to Section "3" and Validate I am in "They trust us" page
	Then I navigate to Section "4" and Validate I am in "Locations" page
	And I Click on next location and see the counter was increased and Current location changed
	And I Click Current Location and see I navigated to "Global Office Directory" page
	And I Click on Main page link
	Then I navigate to Section "5" and Validate I am in "Top Gun Lab" page
	And I Click Top Gun Page Ling to See More and validate I am redirected to "Education" page
	And I Click on Main page link
	Then I navigate to Section "6" and Validate I am in "Empower Your Career" page
	#Then I navigate to Section "7" and Validate I am in "Contact Sales" page
	Then I Click Team Message, Validate i have "executive leadership located" in the text and click Got It
	Then I Click Contact Sales
	#And I fill Contact Sales Form with first Name "firstName", lastName "lastName", company "company", email "email", phone "phone" and message "message"  