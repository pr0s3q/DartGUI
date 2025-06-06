# Player statistics Ideas
## 1. Average Points (3-dart average) ✅
Formula: (Total Points Scored / Total Darts Thrown) * 3

Tracks how efficient the player is.

## 2. Most Common Field Hit ✅
Count how many times each numbered segment (1–20, bullseye, outer bull, doubles, triples) is hit.

Use a dictionary or tally counter.

Example: {"T20": 5, "D16": 3, "20": 7, "Bull": 2}

## 3. Biggest Checkout ✅
Largest score a player ends a leg on, using a valid double or bull.

Track highest "finishing score" in a round.

Example: Player A finished 170 (T20 + T20 + Bull)

## 4. Most Common Double to End a Leg ✅
Count which double was used most often to win a leg.

Filter only the last dart of each leg.

Example: {"D16": 4, "D20": 2}

## 5. Highest Scoring Visit
Most points scored in a single turn (usually 3 darts).

Store each visit and update if it beats previous.

## 6. Checkout Efficiency
Formula: (Checkouts Completed / Attempts at Checkout) * 100

Useful for understanding pressure handling.

## 7. Double Accuracy
Track double attempts and successes across the game.

Breakdown: D20: 4/10, D16: 2/3

## 8. Number of 180s, 140+, 100+ Scores ✅
Tally power scores (180s especially important).

## 9. "Darts at Leg" or "Leg Darts"
This refers to the total number of darts thrown by the player from the start of the leg until it is completed.

## 10. Detailed leg statistics
Statistics of each leg:
- Player average score
- Leg Darts (look no 9)