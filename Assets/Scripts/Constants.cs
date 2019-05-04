namespace Constants {

	public class BOARD {
		public readonly static int LENGTH = 3;
		public readonly static int CARD_CAPACITY = LENGTH * LENGTH;
		public readonly static int GRID_SPACE_X = 266;
		public readonly static int GRID_SPACE_Y = 320;
	}

	public class PLAYER {
		public readonly static int HAND_LENGTH = 5;
		public readonly static int HAND_SPACE_X = 620;
		public readonly static int HAND_SPACE_Y = 320;
		public readonly static int HAND_SPACE_OFFSET_X = 70;
		public readonly static int HAND_SPACE_OFFSET_Y = HAND_SPACE_Y/2;
	}

	public class CURSOR {
		public readonly static int SPACE_OFFSET_X = 180;
		public readonly static int SPACE_X = -PLAYER.HAND_SPACE_OFFSET_X - SPACE_OFFSET_X;
	}
}
